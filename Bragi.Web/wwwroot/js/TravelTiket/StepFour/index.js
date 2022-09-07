var publicHealth = {
    PublicHealthCountries: [],
    PublicHealthStopOvers: []
}

function stopOverCountries(personIndex) {
    var input = document.getElementById('country-' + personIndex);

    var filter = input.value.toUpperCase();
    var ul = document.getElementById('ulcountries-' + personIndex);
    var li = ul.getElementsByTagName('li');
    for (var i = 0; i < li.length; i++) {
        var name = li[i].getElementsByTagName('a')[0].attributes[0].value;
        name = name.trim();
        if (name.toUpperCase().indexOf(filter) === 0)
            li[i].style.display = 'list-item';
        else
            li[i].style.display = 'none';
    }
}

function lastVisitedCountries(personIndex) {
    var input = document.getElementById('lastVisit-' + personIndex);
    var filter = input.value.toUpperCase();
    var ul = document.getElementById('ulvisitedcountries-' + personIndex);
    var li = ul.getElementsByTagName('li');
    for (var i = 0; i < li.length; i++) {
        var name = li[i].getElementsByTagName('a')[0].attributes[0].value;
        name = name.trim();
        if (name.toUpperCase().indexOf(filter) === 0)
            li[i].style.display = 'list-item';
        else
            li[i].style.display = 'none';
    }
}

async function postPh(url, phStopOver) {
    var response = await fetch(url,
        {
            method: 'POST',
            mode: 'cors',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(phStopOver)
        });
    return response.json();
}

async function deletePh(url, id) {
    var response = await fetch(url,
        {
            method: 'DELETE',
            mode: 'cors',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(id)
        });
    return response.json();
}

async function postSymptom(url, obj) {
    var response = await fetch(url,
        {
            method: 'PUT',
            mode: 'cors',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(obj)
        });
    return response.json();
}

function addStopover(personIndex, countryId, phId, imageCode, countryName) {
    var arr = publicHealth.PublicHealthStopOvers;
    if (arr) {
        var exist = arr.find(x => x.CountryId === countryId);
        if (exist) return;
    }
    var ph = {
        CountryId: countryId,
        PublicHealthId: phId
    };

    publicHealth.PublicHealthStopOvers.push(ph);

    postPh('/api/PublicHealthStopOver', ph).then(function (data) {
        $('#stopOverContainer-' + personIndex).append(`
        <div class="col-lg-2  col-md-6 mt-2" id="stopover-${personIndex}-${data.id}"  style="cursor:pointer;">
              <div class="card  w-100">
             <div class="card-body d-flex justify-content-between align-items-center">
        <div class="tamano">
            <img src="/img/Countries/${imageCode}.svg" class="img-country" width="40" height="40" style="border-radius: 100px;" />
            <b>${countryName}</b>
       </div>
              <button type="button" class="btn" onclick="deleteStopOver('${personIndex}','${data.id}')"> <i class="fas fa-trash icon-tash align-item-start"></i></button>
          </div>   
           </div>
        </div>
    `);
    });
}

function addLastVisited(personIndex, countryId, phId, imageCode, countryName) {

    var arr = publicHealth.PublicHealthCountries;
    if (arr) {
        var exist = arr.find(x => x.CountryId === countryId);
        if (exist) return;
    }
    var ph = {
        CountryId: countryId,
        PublicHealthId: phId
    };
    publicHealth.PublicHealthCountries.push(ph);
    postPh('/api/PublicHealthCountries', ph).then(function (data) {
        $('#countriesContainer-' + personIndex).append(`
        <div class="col-lg-2  col-md-6 mt-2" id="country-${personIndex}-${data.id}" style="cursor:pointer;">
             <div class="card  w-100">
                 <div class="card-body d-flex justify-content-between align-items-center">
            <div class="tamano"> 
            <img src="/img/Countries/${imageCode}.svg" class="img-country" width="40" height="40" style="border-radius: 100px;" />
            <b class="ml-1">${countryName}</b>
          </div>
            <button type="button" class="btn" onclick="deleteVisitedCountry('${personIndex}','${data.id}')"> <i class="fas fa-trash icon-tash align-item-start"></i></button>
          </div>
            </div>
        </div>
    `);
    });
}

function addSymptom(personIndex, questionId, phId, questionResponseId) {
    var hasNoSymptom = checkHasNoSymptomChecked(personIndex);

    var qresponse = {
        Id: questionResponseId,
        QuestionId: questionId,
        BoolResponse: false,
        PublicHealthId: phId
    }

    if (!hasNoSymptom && questionId !== getNoSymptomQuestionId().toString()) {
        var isChecked = document.getElementById('checkbox-' + questionResponseId).checked;
        qresponse.BoolResponse = isChecked;

        postSymptom('/api/QuestionResponse', qresponse).then(function (data) {
        });

        return;

    } else if (questionId === getNoSymptomQuestionId().toString()) {
        qresponse.BoolResponse = hasNoSymptom;

        postSymptom('/api/QuestionResponse', qresponse).then(function (data) {
        });

        changeSymptomCheckBoxesWhenNoSymptom(personIndex, hasNoSymptom);
        return;

    }

    changeSymptomCheckBoxesWhenNoSymptom(personIndex, hasNoSymptom);

}

function changeSymptomCheckBoxesWhenNoSymptom(personIndex, hasNoSymptom) {
    var symptomCheckBoxes = $(`.symptom-checkbox-${personIndex}`);
    if (symptomCheckBoxes.length > 0) {
        for (var i = 0; i < symptomCheckBoxes.length; i++) {
            if ($(symptomCheckBoxes[i]).data("questionid") !== getNoSymptomQuestionId()) {
                var wasPrevChecked = $(symptomCheckBoxes[i]).is(":checked");
                $(symptomCheckBoxes[i]).prop("checked", false);
                $(symptomCheckBoxes[i]).prop("disabled", hasNoSymptom);

                if (wasPrevChecked) {
                    var qresponse = {
                        Id: $(symptomCheckBoxes[i]).data("questionresponseid"),
                        QuestionId: $(symptomCheckBoxes[i]).data("questionid"),
                        BoolResponse: false,
                        PublicHealthId: $(symptomCheckBoxes[i]).data("phid")
                    }

                    postSymptom('/api/QuestionResponse', qresponse).then(function (data) {
                    });
                }

            }
        }
    }
}

function checkHasNoSymptomChecked(personIndex) {
    var selectedCheckBoxes = getAllSelectedSymptoms(personIndex);
    return selectedCheckBoxes.find(x => x === getNoSymptomQuestionId()) > 0;
}

function deleteStopOver(personIndex, id) {
    deletePh(`/api/PublicHealthStopOver/${id}`).then(function (data) {
        var element = document.getElementById(`stopover-${personIndex}-${id}`);
        element.remove();
    });
}

function deleteVisitedCountry(personIndex, id) {
    deletePh(`/api/PublicHealthCountries/${id}`).then(function (data) {
        var element = document.getElementById(`country-${personIndex}-${id}`);
        element.remove();
    });
}

async function handleSubmitWithoutValidate(personIndex, isLastPerson, applicationId) {
    if (isLastPerson) {
        await wasHelpedQuestion().then(async (result) => {
            if (result.value) {
                await wasHelpedForm().then(async (result) => {
                    if (result.value) {
                        await acceptTermsForm(personIndex, isLastPerson, applicationId);
                    }
                });
            } else {
                await acceptTermsForm(personIndex, isLastPerson, applicationId);
            }
        });

        return;
    }

    $(`#form-${personIndex}`).submit();
}

async function handleSubmit(personIndex, isLastPerson, applicationId) {


    if (validateForm(personIndex)) {
        if (isLastPerson) {
            await wasHelpedQuestion().then(async (result) => {
                if (result.value) {
                    await wasHelpedForm().then(async (result) => {
                        if (result.value) {
                            await acceptTermsForm(personIndex, isLastPerson, applicationId);
                        }
                    });
                } else {
                    await acceptTermsForm(personIndex, isLastPerson, applicationId);
                }
            });

            return;
        }

        $(`#form-${personIndex}`).submit();
    }
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

async function acceptTermsForm(personIndex, isLastPerson, applicationId) {
    var { acceptTermsTitle, aceptTermDgaText, aceptTermDgmText, aceptTermMSP } = getTraslations();


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
            CommonsService.acceptTerms(applicationId).then(async (result) => {
                if (result.status === 200) {
                    $(`#form-${personIndex}`).submit();
                }
                //document.location.href = `/travelticket/ticketemision${token}`;
            });
        }
    }).catch((e) => { console.log(e) });
}

function validateForm(personIndex) {
    var isValid = true;
    var formId = `form-${personIndex}`;
    clearValidationSpans(formId);
    var selectedHealthSymptoms = getAllSelectedSymptoms(personIndex);

    if (selectedHealthSymptoms.length === 0) {
        var { mustSelectSymptom } = getTraslations();
        setCustomValidationMessageForInput(formId, `QuestionResponse`, mustSelectSymptom);
        isValid = false;

    } else {
        var hasNoSymptoms = selectedHealthSymptoms.find(x => x === getNoSymptomQuestionId()) !== undefined;

        if (!hasNoSymptoms) {
            var isSymptomDateValid = validateSymptomDate(formId);
            if (!isSymptomDateValid) {
                isValid = false;
            }
        }
    }

    if (!validatePhoneNumber(formId)) {
        isValid = false;
    }

    return isValid;
}

function validateSymptomDate(formId) {
    var sympstomDateEmpty = validateInputNotEmpty(formId, 'SymptomsDate');
    if (sympstomDateEmpty) {
        var symptomDate = $(`#${formId} #SymptomsDate`).val();

        var today = new Date();
        var dd = String(today.getDate()).padStart(2, '0');
        var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
        var yyyy = today.getFullYear();

        today = `${yyyy}-${mm}-${dd}`;

        if (symptomDate > today) {
            var { dateSmallerThanCurrent } = getTraslations();
            setCustomValidationMessageForInput(formId, "SymptomsDate", dateSmallerThanCurrent);
            return false;
        }

        return true;
    }

    return false;
}

function validateInputNotEmpty(formId, inputId) {
    var input = getInputByFormAndId(formId, inputId);
    var inputValue = input.val();

    if (inputValue.trim().length === 0) {
        setValidationMessageForInput(formId, inputId, "val-required");
        return false;
    } else if (checkInputRequiresMatching(input)) {
        if (!checkInputValueMatchRegex(input)) {
            setValidationMessageForInput(formId, inputId, "val-regex");
            return false;
        }
    }

    return true;
}

function validatePhoneNumber(formId) {
    var isUnderAge = $(`#${formId} #IsUnderAge`).val() === "True";
    if (!isUnderAge) {
        var phoneNumberEmpty = validateInputNotEmpty(formId, 'PhoneNumber');
        return phoneNumberEmpty;
    }

    return true;
}

function getAllSelectedSymptoms(personIndex) {
    var checkboxes = $(`.symptom-checkbox-${personIndex}:checked`);
    var selectedSymptoms = [];
    if (checkboxes.length > 0) {
        for (var i = 0; i < checkboxes.length; i++) {
            selectedSymptoms.push($(checkboxes[i]).data("questionid"));
        }
    }
    return selectedSymptoms;
}