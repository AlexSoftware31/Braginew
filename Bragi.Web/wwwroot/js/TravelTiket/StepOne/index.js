

function initializeComponents() {
    //$('#selectMunicipality').find('option').remove();
    $('#countryRes').selectpicker('destroy');
    $('#countryRes').selectpicker();
}

function selectCountry() {
    $('#cityId').val('');
    $('#stateName').val('');
    $('#cityName2').val('');
}

function selectCity(cityId, state, cityName) {
    $('#cityId').val(cityId);
    $('#stateName').val(state);
    $('#cityName2').val(cityName);
    $('#cityModal').modal('hide');
    $('#cityName').val('');
    $('#ulcities').empty();
}



async function populateCountries() {
    var request = await GeoLocationService.getAllContries();
    var countries = await request.data;
    $.each(countries,
        function (index, country) {
            $('#countryRes').append(`<option data-tokens='${country.iso2}' value='${country.iso2}'>${country.name}</option>`);
        });
}


async function searchCity() {
    var { CityValidate, awaitMoment, noCityFound, pickACountry } = getTraslations();

    var countryiso2 = $("#countryRes option:selected").attr('iso2');
    if (countryiso2 === undefined || countryiso2 === "") {
        Swal.fire({
            title: pickACountry,
            type: 'info'
        });
        return;
    }

    var cityName = $('#cityName').val();
    $('#ulcities').empty();
    if (cityName.length < 1) {
        //  var { allFiledsRequired } = getTraslations();
        Swal.fire({
            title: `${CityValidate}`,
            type: 'info',
            showConfirmButton: true,
            showCancelButton: false,
            confirmButtonText: "Ok"
        });
        return;
    }
    Swal.showLoading();
    await CommonsService.getCitiesbyName(countryiso2, cityName)
        .then(async function(result) {
            var cities = result.data;
            if (cities.length > 0) {
                $.each(cities,
                    function(index, city) {
                        $('#ulcities').append(`
                         <li class="list-group-item list-group-item-action" style="border-top: 1px solid #e0e0e0" onclick="selectCity(${
                            city.id},'${city.state.replace("'", " ")}','${city.name.replace("'", " ")}')"> 
                                <a class="title">
                                        <b>${city.name}</b>
                                </a> 
                                <br />
                                <span>
                                    ${city.state}
                                </span>
                            </li>`);
                    });
                Swal.close();
            } else {
                Swal.fire({
                    title: `${noCityFound}`,
                    type:'info'
                });
            }
        });
}










