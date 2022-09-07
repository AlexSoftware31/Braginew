
/**
 * ENUMS
 */

var ENUMS = {
    FormStep: {
        GENERAL_INFORMATION: 0,
        MIGRATORY_INFORMATION: 1,
        CUSTOMS_INFORMATION: 2,
        PUBLIC_HEALT: 3
    },
    LANGUAJES: {
        SPANISH: "spanish",
        ENGLISH: "english",
        Russian: "russian",
        Italian: "italian",
        Portuguese: "portuguese",
        German: "german",
        French: "french"
    },
    ALERT_TYPES: {
        ERROR: "error",
        SUCCESS: "success",
        WARNING: "warning",
        INFO: "info"
    },
    ALERT_WAS_HELPED: {
        VALIDATIONS: 0,
        CANCELED: 1,
        SUCCESS: 2
    }
};

/**
 * 
 */

/**
 * METHODS
 */

var notSpecialCharacters = function (node = "input") {
    $(node).keypress(function (e) {
        if (e.target.type === 'email') {
            return true;
        }
        var keyCode = e.keyCode || e.which;
        var regex = /^[ A-Za-z0-9]+$/;
        var isValid = regex.test(String.fromCharCode(keyCode));
        return isValid;
    });
};

var isRequiredScale = function (v) {
    if ($('#isScale').is(':checked')) {
        $('#willStay').prop('required', true);
        $('#willScale').prop('required', true);
    } else {
        $('#willScale').removeAttr('required');
        $('#willStay').removeAttr('required');
    }
};

var loadDateTodayPicker = function (time = 0) {
    var { cancel, months, weekdays, weekdaysAbbrev, weekdaysShort, monthsShort } = getTraslations();
    setTimeout(function () {
        $('.datepicker-today')
            .datepicker({
                i18n: {
                    months: months,
                    monthsShort,
                    weekdays,
                    weekdaysAbbrev,
                    weekdaysShort,
                    cancel
                },
                setDefaultDate: true,
                yearRange: [1910, new Date().getFullYear()],
                format: "dd/mm/yyyy",
                maxDate: new Date()
            });
        $('.datepicker-today').keypress(function (e) {
            e.preventDefault();
        });

    }, time);
};

var loadDatePickerLibrary = function (time = 1300) {

    $('.modal').modal();
    $('.datepicker').keypress(function (e) { e.preventDefault(); });
    notSpecialCharacters();
    setTimeout(function () {
        var { cancel, months, monthsShort, weekdays, weekdaysAbbrev, weekdaysShort } = getTraslations();
        $('.datepicker').datepicker({
            i18n: {
                months: months, monthsShort
                , weekdays, weekdaysAbbrev, weekdaysShort, cancel
            },
            setDefaultDate: true,
            yearRange: [1910, new Date().getFullYear()],
            format: "dd/mm/yyyy"
        });
        loadDateTodayPicker();
    }, time);
};

var loadDateFlightPicker = function () {
    var { cancel, months, monthsShort, weekdays, weekdaysAbbrev, weekdaysShort } = getTraslations();

    $('.datepicker-Flight').datepicker({
        i18n: {
            months: months, monthsShort,
            weekdays, weekdaysAbbrev, weekdaysShort, cancel
        },
        setDefaultDate: true,
        yearRange: [1910, new Date().getFullYear()],
        format: "dd/mm/yyyy",
        minDate: new Date()
    });
    $('.datepicker-Flight').keypress(function (e) {
        e.preventDefault();
    });
};

var validateInputs = function (containerId) {
    var inputs = document.getElementById(containerId).querySelectorAll('input, textarea, select');
    for (let i = 0; i < inputs.length; i++) {
        if (!inputs[i].checkValidity()) {
            inputs[i].classList.add("invalid");
            inputs[i].classList.add("select-invalid");
            return false;
        } else if (inputs[i].checkValidity()) {
            inputs[i].classList.remove("invalid");
            inputs[i].classList.remove("select-invalid");
        }
    }
    return true;
};

var validateAllInputs = function (containerId) {
    return new Promise(function (resolved, reject) {
        var inputs = document.getElementById(containerId).querySelectorAll('input.validate, textarea, select, .select2');
        var validationHandler = true;
        var rejectmessage = null;
        inputs.forEach(function (x) {
            if (x.value === '' || x.value === '0') {
                if (!x.classList.contains('datepicker-select')) {
                    x.classList.add("invalid");
                    if (x.nodeName === "SELECT") {
                        x.classList.add("select-invalid");
                    }
                    validationHandler = false;
                    rejectmessage = invalidInputMessages.allInput;
                } else {
                    x.classList.remove("invalid");
                    x.classList.remove("select-invalid");
                }
            } else if (x.id === 'passport') {
                if (x.value.length < 6) {
                    x.classList.add("invalid");
                    if (x.nodeName === "SELECT") {
                        x.classList.add("select-invalid");
                    }
                    validationHandler = false;
                    rejectmessage = invalidInputMessages.passport;
                } else {
                    x.classList.remove("invalid");
                    x.classList.remove("select-invalid");
                }
            } else {
                x.classList.remove("invalid");
                x.classList.remove("select-invalid");
            }
        });
        if (validationHandler) resolved();
        else reject(rejectmessage);
    });
};

var topContent = function () {
    $('html').stop().animate({ scrollTop: 200 }, 500, 'swing', () => { });
};

var loadTabs = function () {
    var tabs = $('.tabs li .clickeadble');
    for (let i = tabs.length - 1; i >= 0; i--) {
        tabs[i].click();
    }
};

var loadNotSpecialCharacters = function () {
    setTimeout(function () { notSpecialCharacters(); }, 800);
};

var invalidInputMessages = {
    passport: 0,
    allInput: 1
};


var loadSelect = function (time = 700) {
    setTimeout(function () {
        $('select:not(.no-search)').formSelect();
    }, time);
};

var loadSelectIn = function (val) {
    if (!val) loadSelect(0);
};


var validateFlightNumber = function () {

    $('.flightNumber').keyup((e) => {
        var result = /[0-9A-Za-z]{3,4}/.test(e.target.value.toUpperCase());
        if (result) e.target.classList.remove("invalid");
        else e.target.classList.add('invalid');
    });

};

var showDatePicker = function (id) {
    $(id).datepicker('open');
};

var setDoneStepper = function (index) {
    if (index === 1) {
        $('#step-1').addClass("done");
    }
    else if (index === 2) {
        $('#step-1').addClass("done");
        $('#step-2').addClass("done");
    }
    else if (index === 3) {
        $('#step-1').addClass("done");
        $('#step-2').addClass("done");
        $('#step-3').addClass("done");
    }
};

function validationFunction(stepperForm, activeStepContent) {
    // You can use the 'stepperForm' to valide the whole form around the stepper:
    someValidationPlugin(stepperForm);
    // Or you can do something with just the activeStepContent
    someValidationPlugin(activeStepContent);
    // Return true or false to proceed or show an error
    return true;
}

function defaultValidationFunction(stepperForm, activeStepContent) {
    var inputs = activeStepContent.querySelectorAll('input, textarea, select');
    for (let i = 0; i < inputs.length; i++) {
        if (!inputs[i].checkValidity()) {
            inputs[i].classList.add("invalid");
            inputs[i].classList.add("select-invalid");
            var { invalidFields, allFiledsRequired } = getTraslations();
            Swal.fire({ title: invalidFields, text: allFiledsRequired, type: ENUMS.ALERT_TYPES.ERROR });
            return false;
        } else if (inputs[i].checkValidity()) {
            inputs[i].classList.remove("invalid");
            inputs[i].classList.remove("select-invalid");
        }
    }
    return true;
}

var validZero = function (time = 100) {
    $(':input[type="number"]').val('');
    setTimeout(function () {
        $(':input[type="number"]').keyup((e) => {
            if (e.target.value < 1) {
                e.target.classList.remove('valid');
                e.target.classList.add('invalid');
                return;
            } else {
                e.target.classList.remove('invalid');
                e.target.classList.add('valid');
                return;
            }
        });
    }, time);
};

var goToTab = function (node) {
    $('ul.tabs').tabs("select", node);
    validZero();
};

/**
 * GET THE TRASLATIONS BASED IN COOKIED AND CALL A CONST WITH 
 * THE TEXT.
 * */
var getTraslations = function () {
    var languaje = $.cookie("Language");
    switch (String(languaje).toLowerCase()) {
        case ENUMS.LANGUAJES.SPANISH: return TRASLATIONS.ES;
        case ENUMS.LANGUAJES.ENGLISH: return TRASLATIONS.EN;

        case ENUMS.LANGUAJES.German: return TRASLATIONS.DE;
        case ENUMS.LANGUAJES.Italian: return TRASLATIONS.IT;
        case ENUMS.LANGUAJES.Portuguese: return TRASLATIONS.PT;
        case ENUMS.LANGUAJES.Russian: return TRASLATIONS.RU;
        case ENUMS.LANGUAJES.French: return TRASLATIONS.FR;
        default: return TRASLATIONS.ES;
    }
};


// travelAuth
var getTraslationsGuide = function () {
    var languaje = $.cookie("Language");
    switch (String(languaje).toLowerCase()) {
        case ENUMS.LANGUAJES.SPANISH: return TRASLATION_GUIDE.ES;
        case ENUMS.LANGUAJES.ENGLISH: return TRASLATION_GUIDE.EN;

        case ENUMS.LANGUAJES.German: return TRASLATION_GUIDE.DE;
        case ENUMS.LANGUAJES.Italian: return TRASLATION_GUIDE.IT;
        case ENUMS.LANGUAJES.Portuguese: return TRASLATION_GUIDE.PT;
        case ENUMS.LANGUAJES.Russian: return TRASLATION_GUIDE.RU;
        case ENUMS.LANGUAJES.French: return TRASLATION_GUIDE.FR;
        default: return TRASLATION_GUIDE.ES;
    }
};

// travelTicket 
var getTraslationsGuideTravelTicket = function () {
    var languaje = $.cookie("Language");
    switch (String(languaje).toLowerCase()) {
        case ENUMS.LANGUAJES.SPANISH: return TRASLATION_GUIDE_TRAVELTICKET.ES;
        case ENUMS.LANGUAJES.ENGLISH: return TRASLATION_GUIDE_TRAVELTICKET.EN;

        case ENUMS.LANGUAJES.German: return TRASLATION_GUIDE_TRAVELTICKET.DE;
        case ENUMS.LANGUAJES.Italian: return TRASLATION_GUIDE_TRAVELTICKET.IT;
        case ENUMS.LANGUAJES.Portuguese: return TRASLATION_GUIDE_TRAVELTICKET.PT;
        case ENUMS.LANGUAJES.Russian: return TRASLATION_GUIDE_TRAVELTICKET.RU;
        default: return TRASLATION_GUIDE_TRAVELTICKET.ES;
    }
};


var loadPhoneMask = function () {
    //$('.phoneNumber').mask("000-000-0000");
};

var loadingPage = function () {
    var { loadingInfo } = getTraslations();
    Swal.fire({
        title: loadingInfo,
        text: "",
        backdrop: `#fff`,
        showConfirmButton: false
    });
    Swal.showLoading();
    setTimeout(() => {
        Swal.close();
    }, 1300);
};

var isUnauthorized = function () {
    var { sorry, timeLimitExceed } = getTraslations();
    Swal.fire(sorry, timeLimitExceed, ENUMS.ALERT_TYPES.ERROR).then(() => location.href = "/Auth/TravelLogin").catch(() => location.href = "/Auth/TravelLogin");
};

var loadModal = function () {
    $('.modal').modal();

}

var loadPickerOrigin = function () {
    setTimeout(function () {
        $('.datepicker-PORT').datepicker({
            setDefaultDate: true,
            format: "dd/mm/yyyy",
            minDate: new Date()
        });
    }, 1000)
}


var notRussian = function () {
    const { noRussian } = getTraslations();
    const inputRussian = $(".not-russian");
    inputRussian.keyup(function (event) {
        const result = /[а-яА-ЯЁё]/.test(event.target.value);
        if (result) {
            Swal.fire(
                "",
                noRussian,
                "error"
            );
            this.value = "";
        }
    });
}

function setValidationMessageForInput(formId, inputId, messageDataName) {
    if (formId && inputId && messageDataName) {
        var input = getInputByFormAndId(formId, inputId);
        var validationSpan = getValidationSpan(formId, inputId);

        setValidationMessage(validationSpan, input, messageDataName);
    }
}

function setCustomValidationMessageForInput(formId, inputId, message) {
    if (formId && inputId && message) {
        var validationSpan = getValidationSpan(formId, inputId);

        setValidationMessageOnSpan(validationSpan, message);
    }
}

function getInputByFormAndId(formId, inputId) {
    return $(`#${formId} #${inputId}`);
}

function getValidationSpan(formId, inputId) {
    return $(`#${formId} [data-valmsg-for='${inputId}']`);
}

function setValidationMessage(validationSpan, input, message) {
    if (validationSpan && input && message) {
        setValidationMessageOnSpan(validationSpan, getValidationMessageFromInput(input, message));
    }
}

function setValidationMessageOnSpan(validationSpan, message) {
    if (validationSpan) {
        validationSpan.html(message);
    }
}

function getValidationMessageFromInput(input, dataName) {
    if (input) {
        return input.data(dataName);
    }

    return "";
}

function checkInputRequiresMatching(input) {
    if (input) {
        var regexData = getInputRegex(input);
        return regexData && regexData.length > 0;
    }

    return false;
}

function checkInputValueMatchRegex(input) {
    if (input) {
        return input.val().match(getInputRegex(input));
    }

    return true;
}

function getInputRegex(input) {
    if (input) {
        return input.data("val-regex-pattern");
    }

    return "";
}

function clearValidationSpans(formId) {
    $(`#${formId} .field-validation-valid`).html("");
}

function getNoSymptomQuestionId() {
    return 6;
}
