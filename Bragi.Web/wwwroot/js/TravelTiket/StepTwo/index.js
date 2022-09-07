async function populateMunicipalities(personIndex) {
    if (personIndex === undefined) return;
    var province = document.getElementById('selectProvinces-' + personIndex).value;
    if (province === "") return;
    var result = await GeoLocationService.getMunicipalities(province);
    var munips = await result.data;

    $('#selectMunicipality-' + personIndex).find('option').remove();
    $('#selectMunicipality-' + personIndex).selectpicker('destroy');

    $.each(munips,
        function (index, data) {
            $('#selectMunicipality-' + personIndex).append(`<option data-tokens='${data.toponomyName}' value='${data.municipalities}'>${data.toponomyName}</option>`);
        });


    $('#selectMunicipality-' + personIndex).selectpicker();
    await populateSectors(personIndex);
}

async function populateSectors(personIndex) {
    if (personIndex === undefined) return;

    var province = document.getElementById('selectProvinces-' + personIndex).value;
    var municipality = document.getElementById('selectMunicipality-' + personIndex).value;


    var result = await GeoLocationService.getSectors(province, municipality);
    var sectors = await result.data;
    $('#selectSector-' + personIndex).find('option').remove();
    $('#selectSector-' + personIndex).selectpicker('destroy');

    $.each(sectors,
        function (index, data) {
            $('#selectSector-' + personIndex).append(`<option data-tokens='${data.toponomyName}' value='${data.geoCode}'>${data.toponomyName}</option>`);
        });


    $('#selectSector-' + personIndex).selectpicker();

    var geocode = $('#selectSector-' + personIndex).val();
    $('#geocode-' + personIndex).val(geocode);
}

async function geoSet(province, municipality, geocode, personIndex) {
    if (personIndex === undefined) return;
    if (geocode !== '' && geocode !== undefined && geocode !== null) {

        $('#selectProvinces-' + personIndex).selectpicker('val', province);
        await populateMunicipalities();

        $('#selectMunicipality-' + personIndex).selectpicker('val', municipality);
        await populateSectors();

        $('#selectSector-' + personIndex).selectpicker('val', geocode.toString());
    }
}

function toggleSpecificFlightMotive(personIndex) {
    if (personIndex === undefined) return;

    var val = $('#flightMotiveId-' + personIndex).val();

    if (val === "1") {
        $('#specificFlight-' + personIndex).show();
        $('#specificFlight-' + personIndex).removeAttr('hidden');
        return;
    }
    if (val !== "1") {
        $('#specificFlight-' + personIndex).hide();
        $('#specificFlight-' + personIndex).val('');
        return;
    }
}

function toggleBirthPlace(personIndex) {
    if (personIndex === undefined) return;

    var birthPlace = $("#MigratoryInformation_BirthPlace").val();
    if (birthPlace == "DOM") {
        var isArrival = $("#MigratoryInformation_IsArrival").val();
        if (isArrival == 'true') {
            //Validate Age
            var DateBirthDay = document.querySelector("#dobSelect-" + personIndex).valueAsDate;
            var Age = calculateAge(DateBirthDay);
            if (Age >= 18) {
                showTaskReturn(personIndex);
            }
        }
        return;
    }
    else {
        hideTaskReturn(personIndex);
        cleanTaskReturn(personIndex);
        toggleDOMTaskReturn(personIndex)
    }
}

function toggleDocumentNumber(personIndex) {
    if (personIndex === undefined) return;

    var nationality = $('#selectNat-' + personIndex).val();
    if (nationality.toUpperCase() === "DOM") {
        $('#documentIdContainer-' + personIndex).show();
        $('#checkIsResident-' + personIndex).bootstrapToggle('off');
        // $('#documentIdNum-' + personIndex).attr('required');
        hideIsResident(personIndex);
        hideStayingDays(personIndex);
        return;
    } else {
        $('#documentIdContainer-' + personIndex).hide();
        showStayingDays(personIndex);
        showIsResident(personIndex);
    }
}

function calculateAge(birthday) {
    var ageDifMs = Date.now() - birthday.getTime();
    var ageDate = new Date(ageDifMs);
    return Math.abs(ageDate.getUTCFullYear() - 1970);
}

function toggleHotel(personIndex, isPrincipal) {
    if (personIndex === undefined) return;
    var willStayAtResort = document.getElementById('willStayAtResort-' + personIndex).checked;
    handleCommonAddressContainer(personIndex);
    if (willStayAtResort) {
        $('#commonHotelContainer-' + personIndex).show();
        showHotels(personIndex);
        hideDomAddress(personIndex);
        if (!isPrincipal) {
            toggleCommonHotel(personIndex, isPrincipal);
            hideDomAddress(personIndex);
        }
        return;
    }
    else {
        $('#isCommonHotel-' + personIndex).bootstrapToggle('off');
        hideHotels(personIndex);
        $('#commonHotelContainer-' + personIndex).hide();
        showDomAddress(personIndex);
        return;
    }

}

function toggleIsResidence(personIndex) {
    if (personIndex === undefined) return;
    var val = document.getElementById('checkIsResident-' + personIndex).checked;
    if (val) {
        $('#residenceNumb-' + personIndex).show();
        $('#residenceNumb-' + personIndex).removeAttr('hidden');
        hideStayingDays(personIndex);
        return;
    }
    else {
        $('#residenceNumb-' + personIndex).hide();
        showStayingDays(personIndex);
        return;
    }

}


function toggleIsTaskReturnLoadPage(personIndex, isTaskReturn) {
    try {
        if (isTaskReturn == 'True') {
            $('#cedulaNumb-' + personIndex).show();
            $('#TaxTelefonoNumb-' + personIndex).show();
            $('#cedulaNumb-' + personIndex).removeAttr('hidden');
            $('#TaxTelefonoNumb-' + personIndex).removeAttr('hidden');
            $('.IsTaskReturn-' + personIndex).removeAttr('hidden');
            return;
        }
        else {
            cleanTaskReturn();
        }
    } catch (e) {
        console.log(e);
        return;
    }
}

function toggleIsTaskReturnModal(personIndex) {
    if (personIndex === undefined) return;
    var isChecked = document.getElementById('checkIsTaskReturn-' + personIndex).checked;
    if (isChecked) {
        Swal.fire({
            title: "Debe tener un número de cédula y un número de celular de República Dominicana validos",
            text: "¿Desea continuar?",
            type: 'warning',
            allowOutsideClick: false,
            allowEscapeKey: false,
            showCancelButton: true,
            confirmButtonText: 'Si',
            cancelButtonText: 'No'
        }).then((result) => {
            if (result.value) {
                toggleIsTaskReturn(personIndex, true);
            }
            else if (result.dismiss === Swal.DismissReason.cancel) {
                toggleIsTaskReturn(personIndex, false);
            }
        });
        return;
    } else {
        $('#cedulaNumb-' + personIndex).hide();
        $('#TaxTelefonoNumb-' + personIndex).hide();
        $('#checkIsTaskReturn-' + personIndex).bootstrapToggle('off', true);
        return;
    }
}

function toggleIsTaskReturn(personIndex, isConfirmed) {
    if (personIndex === undefined) return;
    var val = document.getElementById('checkIsTaskReturn-' + personIndex).checked;
    if (val && isConfirmed) {
        $('#cedulaNumb-' + personIndex).show();
        $('#TaxTelefonoNumb-' + personIndex).show();
        $('#cedulaNumb-' + personIndex).removeAttr('hidden');
        $('#TaxTelefonoNumb-' + personIndex).removeAttr('hidden');

        return;
    }
    else {
        $('#cedulaNumb-' + personIndex).hide();
        $('#TaxTelefonoNumb-' + personIndex).hide();
        $('#checkIsTaskReturn-' + personIndex).bootstrapToggle('off', true);
        return;
    }
}

function toggleCommonHotel(personIndex, isPrincipal) {
    if (personIndex === undefined) return;

    if (isPrincipal !== undefined && !isPrincipal) {
        var willStayAtResort = document.getElementById('willStayAtResort-' + personIndex).checked;
        var isCommonHotelChecked = document.getElementById('isCommonHotel-' + personIndex).checked;


        if (willStayAtResort) {
            $('#commonHotelContainer-' + personIndex).show();
            hideHotels(personIndex);
            $('#domAddress-' + personIndex).hide();
            if (isCommonHotelChecked) {
                hideHotels(personIndex);
            } else {
                showHotels(personIndex);
            }
            return;
        } else {
            $('#commonHotelContainer-' + personIndex).hide();
            //showHotels(personIndex);
            hideHotels(personIndex);

            return;
        }
    }
    return;
}

function toggleCommonAddress(personIndex, isPrincipal) {

    try {
        if (!isPrincipal) {
            var val = document.getElementById('isCommonAddress-' + personIndex).checked;
            if (val) {
                $('#willStayAtResort-' + personIndex).bootstrapToggle('off');
                $('#willstayAtResortContainer-' + personIndex).hide();
                $('#domAddress-' + personIndex).hide();
            } else {
                $('#domAddress-' + personIndex).show();
                $('#willstayAtResortContainer-' + personIndex).show();
            }
        }
    } catch (e) {
        console.log(e);
        console.log(personIndex);
        console.log(isPrincipal);
    }
}

function toggleAirlines(personIndex) {
    var isOther = $('#selectAirline-' + personIndex).val() === "832";

    if (isOther) {
        showOtherAirlines(personIndex);
        return;
    }
    hideOtherAirlines(personIndex);

}

function initializeComponents() {
    $('.myDate').datepicker({
        format: 'dd/mm/yyyy',
        startDate: '-120y'
        //startView:'0d'
    });
}


function showDomAddress(personIndex) {
    $('#domAddress-' + personIndex).show();
    $('#txtStreet-' + personIndex).attr('required', true);
}


function hideDomAddress(personIndex) {

    $('#domAddress-' + personIndex).hide();
    $('#txtStreet-' + personIndex).attr('required', false);
}


function showHotels(personIndex) {
    $('#hotelselect-' + personIndex).removeAttr('hidden');
    $('#hotelselect-' + personIndex).show();
}


function hideHotels(personIndex) {
    $('#hotelselect-' + personIndex).hide();
}

function handleCommonAddressContainer(personIndex) {

    var willStayAtResort = document.getElementById('willStayAtResort-' + personIndex).checked;

    if (willStayAtResort) {
        $('#isCommonAddress-' + personIndex).bootstrapToggle('off');
        $('#isCommonAddressContainer-' + personIndex).hide();
    } else {
        $('#isCommonAddressContainer-' + personIndex).show();

    }
}

function showIsResident(personIndex) {
    $('#isResidentContainer-' + personIndex).show();
}

function hideIsResident(personIndex) {
    $('#isResidentContainer-' + personIndex).hide();
}


function showTaskReturn(personIndex) {
    $(".IsTaskReturn-" + personIndex).removeAttr('hidden')
    $('.IsTaskReturn-' + personIndex).show();
}

function hideTaskReturn(personIndex) {
    $('.IsTaskReturn-' + personIndex).attr('hidden', true);
    $('.IsTaskReturn-' + personIndex).hide();
}

function cleanTaskReturn(personIndex) {
    $('#MigratoryInformation_TaxReturnInfo_Telefono').val('');
    $('#MigratoryInformation_TaxReturnInfo_Cedula').val('');
}

function toggleDOMTaskReturn(personIndex) {
    $('#checkIsTaskReturn-' + personIndex).bootstrapToggle('off');
    $('#checkIsTaskReturn-' + personIndex).hide();
}



function showOtherAirlines(personIndex) {
    $('#transportCompany-' + personIndex).removeAttr('hidden');
    $('#transportCompany-' + personIndex).show();
}

function hideOtherAirlines(personIndex) {
    $('#transportCompany-' + personIndex).attr('hidden', true);
    $('#transportCompany-' + personIndex).hide();
}

function hideStayingDays(personIndex) {
    $('#stayingDaysContainer-' + personIndex).hide();
}
function showStayingDays(personIndex) {
    $('#stayingDaysContainer-' + personIndex).show();
}

$("form").submit(function (event) {
    var $form = $(this);
    var id = $form.attr('id');
    var index = $form.data("index");
    clearValidationSpans(id);
    var geoCodeValid = validateGeoCode(id, index);
    var hotelValid = validateHotel(id, index);
    if (!hotelValid || !geoCodeValid) {
        event.preventDefault();

    }
});

function validateGeoAndHotel(index) {
    var formId = `form-${index}`;
    clearValidationSpans(formId);
    var geoCodeValid = validateGeoCode(formId, index);
    var hotelValid = validateHotel(formId, index);
    return geoCodeValid && hotelValid;
}

function validateGeoCode(formId, index) {
    var willStayAtResort = $(`#willStayAtResort-${index}`).prop("checked");
    var isCommonAddress = $(`#isCommonAddress-${index}`).prop("checked");
    if (!isCommonAddress && !willStayAtResort) {
        var provinceValid = validateInputNotEmpty(formId, `selectProvinces-${index}`);
        var municiplaityValid = validateInputNotEmpty(formId, `selectMunicipality-${index}`);
        var sectorValid = validateInputNotEmpty(formId, `selectSector-${index}`);
        var geoCodeValid = provinceValid && municiplaityValid && sectorValid;

        return geoCodeValid;
    }

    return true;
}

function validateHotel(formId, index) {
    var willStayAtResort = $(`#willStayAtResort-${index}`).prop("checked");
    var isCommonHotel = $(`#isCommonHotel-${index}`).prop("checked");
    if (willStayAtResort && !isCommonHotel) {
        var hotelValid = validateInputNotEmpty(formId, "MigratoryInformation_HotelId");

        return hotelValid;
    }

    return true;
}

function validateInputNotEmpty(formId, inputId) {
    var input = getInputByFormAndId(formId, inputId);
    var inputValue = input.val();

    if (inputValue.trim().length === 0) {
        var { requiredField } = getTraslations();
        setCustomValidationMessageForInput(formId, inputId, requiredField);
        input.focus();
        return false;
    }

    return true;
}

async function wasHelpedQuestion() {
    var { wasHelpedText, yes, not } = getTraslations();

    return await Swal.fire({
        title: wasHelpedText,
        type: ENUMS.ALERT_TYPES.INFO,
        showConfirmButton: true,
        showCancelButton: true,
        confirmButtonText: yes,
        cancelButtonText: not
    });
}

async function wasHelpedForm() {

    var { fillInformationHelpedForm, yes, cancel, fullName, Relationship } = getTraslations();

    var form = `<div class="container" style="margin-top:30px !important;">
                            <div>
                                <label>${fullName}</label>
                                <input id="wname" class="form-control" /> 
                            </div>
                            <div>
                                <label>${Relationship}</label>
                                <input id="wrelationShip" class="form-control"/>
                            </div>
                          </div>`;
    return await Swal.fire({
        title: fillInformationHelpedForm,
        type: ENUMS.ALERT_TYPES.INFO,
        html: form,
        showConfirmButton: true,
        showCancelButton: true,
        confirmButtonText: yes,
        cancelButtonText: cancel
    });
}

async function acceptTermsForm(applicationId, personIndex) {
    var { acceptTermsTitle, aceptTermDgaText, aceptTermDgmText, aceptTermMSP } = getTraslations();

    console.log("acceptTermsForm");

    var html = `<div> 
                                <img src="/img/DGA.png" style="margin-bottom:-40px;" width="250"/> </br>
                                <p style="margin-bottom:-10px;">${aceptTermDgaText}</p> </br>
                                <img src="/img/dgm.png"  width="225"/> </br>
                                <p style="margin-bottom:-10px;" >${aceptTermDgmText}</p> </br>
                                <img src="/img/logomsp.png"   width="225" /> </br>
                                <p style="margin-bottom:-10px;" >${aceptTermMSP}</p> </br>
                          </div>`;

    await Swal.fire({
        title: acceptTermsTitle,
        html: html,
        type: ENUMS.ALERT_TYPES.INFO,
        showConfirmButton: true,
        showCancelButton: true
    }).then(async (result) => {
        if (result.value) {
            // const token = window.location.search;
            await CommonsService.acceptTerms(applicationId).then(async (result) => {

                console.log(result);
                if (result.status === 200) {
                    console.log("ACCEPT TERMS 200");
                    $(`#form-${personIndex}`).submit();
                } else {
                    event.preventDefault();
                }
                //document.location.href = `/travelticket/ticketemision${token}`;
            });
        } else {
            console.log("canceled acceptTermsForm");
        }

    }).catch((e) => {
        console.log(e);
    });
}


async function submitAction(applicationId, personIndex) {
    var validator = $(`#form-${personIndex}`).validate();
    if (validateGeoAndHotel(personIndex) && validator.form()) {
        await wasHelpedQuestion().then(async (result) => {
            if (result.value) {
                await wasHelpedForm().then(async (result) => {
                    if (result.value) {
                        await acceptTermsForm(applicationId, personIndex);
                    }
                });
            } else {
                await acceptTermsForm(applicationId, personIndex);
            }
        });
    } else {
        validator.focusInvalid();
    }
}