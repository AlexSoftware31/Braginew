var declaredMerchArr = [];

//API Calls
async function postDm(url, obj) {
    var response = await fetch(url,
        {
            method: 'POST',
            mode: 'cors',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(obj)
        });
    return response.json();
}

async function deleteDm(url, id) {
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

function addDeclaredMerch(personIndex, customInfoId) {
    clearDeclarationValidationSpans(personIndex);
    if (!validateMerchForm(personIndex)) return;

    var desc = $('#description-' + personIndex).val();
    var dollarVal = $('#dollarvalue-' + personIndex).val();
    var declaredMerch = {
        CustomsInformationId: customInfoId,
        Description: desc,
        DollarValue: dollarVal
    };


    declaredMerchArr.push(declaredMerch);

    postDm('/api/DeclaredMerch/', declaredMerch).then(function (data) {
        $('#tbody-' + personIndex).append(`
        <tr id="tr-${data.id}">
            <td>${desc}</td>
            <td>${dollarVal}</td>
            <td><button type="button" class="btn" onclick="deleteDeclaration('${personIndex}','${data.id}')"> <i class="fas fa-trash-alt"></i></button></td>
        </tr>`
        );

        $('#description-' + personIndex).val('');
        $('#dollarvalue-' + personIndex).val('');
    });

}

function validateMerchForm(personIndex) {
    var declarationForm = `form-${personIndex}`;
    var isValueMerchValid = validateValueOfMerch(personIndex);
    var isCurrencyMerchandiseValid = validateCurrencyMerchandise(declarationForm);
    var isDescriptionValid = validateDescription(personIndex);
    var isDollarValueValid = validateDollarValue(declarationForm, personIndex);

    return isValueMerchValid && isCurrencyMerchandiseValid && isDescriptionValid && isDollarValueValid;
}

function validateDollarValue(declarationFormId, personIndex) {
    var result = true;
    var inputId = `dollarvalue-${personIndex}`;
    var dollarValueInput = getInputByFormAndId(declarationFormId, inputId);
    var dollarValue = dollarValueInput ? dollarValueInput.val() : "";
    if (dollarValue.length > 0) {

        var ammontNumeric = parseInt(dollarValue);
        if (ammontNumeric <= 0) {
            result = false;
            var { greaterThanZero } = getTraslations();
            setCustomValidationMessageForInput(declarationFormId, inputId, greaterThanZero);
        }
    } else {
        result = false;
        var { requiredField } = getTraslations();
        setCustomValidationMessageForInput(declarationFormId, inputId, requiredField);
    }

    return result;
}

function validateValueOfMerch(personIndex) {
    var declarationForm = `declarationContainer-${personIndex}`;
    var result = true;

    var valueOfMerchtInput = getInputByFormAndId(declarationForm, "ValueOfMerchandise");
    var valueOfMerch = valueOfMerchtInput ? valueOfMerchtInput.val() : "";

    if (valueOfMerch.length > 0) {
        var valueOfMerchNumeric = parseInt(valueOfMerch);
        if (valueOfMerchNumeric && valueOfMerchNumeric <= 0) {
            result = false;
            var { greaterThanZero } = getTraslations();
            setCustomValidationMessageForInput(declarationForm, "ValueOfMerchandise", greaterThanZero);
        }
    } else {
        result = false;
        setValidationMessageForInput(declarationForm, "ValueOfMerchandise", "val-required");
    }

    return result;
}

function validateDescription(personIndex) {
    var formId = `form-${personIndex}`;
    var { requiredField } = getTraslations();
    if (!validateInputNotEmpty(formId, `description-${personIndex}`)) {
        setCustomValidationMessageForInput(formId, `description-${personIndex}`, requiredField);
        return false;
    }

    return true;
}

function validateCurrencyMerchandise(declarationFormId) {
    var result = true;
    var selectedCurrency = $(`#${declarationFormId} #CurrencyMerchandiseId`).val();
    var selectedCurrencyNumeric = parseInt(selectedCurrency);
    if (selectedCurrencyNumeric <= 0) {
        result = false;
        setValidationMessageForInput(declarationFormId, "CurrencyMerchandiseId", "val-required");
    }
    return result;
}

function deleteDeclaration(personIndex, id) {
    deleteDm(`/api/DeclaredMerch/${id}`).then(function (data) {
        document.getElementById(`tr-${id}`).remove();;
    });
}

function setToggleInitialValues(personIndex,exceedMoneyValue, isOwnerValue) {
    $(`#exceedMoneyLimit-${personIndex}`).bootstrapToggle(exceedMoneyValue ? "on" : "off");
    $(`#isValueOwner-${personIndex}`).bootstrapToggle(isOwnerValue ? "on" : "off");
}

function toggleMaxValues(personIndex, isArrival, isUnderAge) {

    if (!isArrival || isUnderAge) return;

    var exceedMoneyLimit = document.getElementById('exceedMoneyLimit-' + personIndex).checked;
    $(`#isValueOwner-${personIndex}`).bootstrapToggle("off");
    if (exceedMoneyLimit) {
        showMaxValuesContainer(personIndex);
        toggleSenderReceiver(personIndex);
        return;
    }
    hideMaxValuesContainer(personIndex);
    toggleSenderReceiver(personIndex);

    return;
}

function toggleSenderReceiver(personIndex) {
    var exceedMoneyLimit = document.getElementById('exceedMoneyLimit-' + personIndex).checked;
    var isValuesOwner = document.getElementById('isValueOwner-' + personIndex).checked;

    if (exceedMoneyLimit) {
        if (isValuesOwner) {
            hideSenderReceiver(personIndex);
            return;
        }

        showSenderReceiver(personIndex);
        return;
    }

    hideSenderReceiver(personIndex);
}

function toggleDeclaration(personIndex, isArrival, isUnderAge) {
    if (!isArrival || isUnderAge) return;
    var needToDeclare = document.getElementById('needToDeclare-' + personIndex).checked;

    if (needToDeclare) {
        showDeclaration(personIndex);
        return;
    }
    hideDeclaration(personIndex);
}

function handleForm(personIndex) {
    if (validateForm(personIndex)) {
        $('#form-' + personIndex)[0].action = "StepThree";
        $('#form-' + personIndex)[0].submit();
    }
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

function clearDeclarationValidationSpans(personIndex) {

    $(`#declarationContainer-${personIndex} .field-validation-valid`).html("");
}

function validateForm(personIndex) {
    var formId = `form-${personIndex}`;
    clearValidationSpans(formId);
    var exceedMoneyInfoValid = validateExceedMoneyInfo(formId, personIndex);
    var declarationValid = validateDeclarationInfo(formId, personIndex);
    return exceedMoneyInfoValid && declarationValid;
    return false;
}

function validateExceedMoneyInfo(formId, personIndex) {
    var exceedMoney = document.getElementById('exceedMoneyLimit-' + personIndex).checked;

    if (exceedMoney) {
        var exceedMoneyIsValid = validateExceedMoney(formId);
        var ownerIsValid = validateOwner(personIndex);
        return exceedMoneyIsValid && ownerIsValid;
    }

    return true;
}

function validateExceedMoney(formId) {
    var result = true;
    var ammountInput = getInputByFormAndId(formId, "Ammount");
    var ammount = ammountInput ? ammountInput.val() : "";
    if (ammount.length > 0) {
        var ammontNumeric = parseInt(ammount);
        if (ammontNumeric <= 0) {
            result = false;
            var { greaterThanZero } = getTraslations();
            setCustomValidationMessageForInput(formId, "Ammount", greaterThanZero);
        }
    } else {
        result = false;
        setValidationMessageForInput(formId, "Ammount", "val-required");
    }

    var selectedCurrency = $(`#${formId} #CurrencyId`).val();
    var selectedCurrencyNumeric = parseInt(selectedCurrency);
    if (selectedCurrencyNumeric <= 0) {
        result = false;
        setValidationMessageForInput(formId, "CurrencyId", "val-required");
    }

    if (!validateInputNotEmpty(formId, "DeclaredOriginValue")) result = false;

    return result;
}

function validateOwner(personIndex) {
    var isOwner = document.getElementById('isValueOwner-' + personIndex).checked;
    if (!isOwner) {
        var formId = `form-${personIndex}`;
        var senderNameValid = validateInputNotEmpty(formId, "SenderName");
        var senderLastNameValid = validateInputNotEmpty(formId, "SenderLastName");
        var receiverNameValid = validateInputNotEmpty(formId, "ReceiverName");
        var receiverLastNameValid = validateInputNotEmpty(formId, "ReceiverLastName");
        var relationshipValid = validateInputNotEmpty(formId, "RelationShip");
        var worthDestinyValid = validateInputNotEmpty(formId, "WorthDestiny");

        return senderNameValid &&
            senderLastNameValid &&
            receiverNameValid &&
            receiverLastNameValid &&
            relationshipValid &&
            worthDestinyValid;
    }

    return true;
}

function validateDeclarationInfo(formId, personIndex) {
    var isDeclaring = document.getElementById('needToDeclare-' + personIndex).checked;
    if (isDeclaring) {
        var declaredStuff = $(`#tbody-${personIndex} tr`);
        var hasDeclaredMerc = declaredStuff.length > 0;
        if (!hasDeclaredMerc) {
            var { mustDeclareMerchandise } = getTraslations();
            setCustomValidationMessageForInput(formId, "DeclaredMerchs", mustDeclareMerchandise);
            return false;
        }
    }

    return true;
}

function addMerch(personIndex) {
    $('#merchContainer-' + personIndex).append(`
        <div id="" class="col-md-4">
            <input class="form-control" name=DeclaredMerchs />
        </div>
        <div id="" class="col-md-4"></div>`);
}

function hideMaxValuesContainer(personIndex) {
    $('#ammountCurrency-' + personIndex).hide();
}

function showMaxValuesContainer(personIndex) {
    $('#ammountCurrency-' + personIndex).show();
}

function showSenderReceiver(personIndex) {
    $('#senderReceiverContainer-' + personIndex).removeAttr('hidden');
    $('#senderReceiverContainer-' + personIndex).show();
}

function hideSenderReceiver(personIndex) {
    $('#senderReceiverContainer-' + personIndex).attr('hidden', true);
    $('#senderReceiverContainer-' + personIndex).hide();
}


function showDeclaration(personIndex) {
    $('#declarationContainer-' + personIndex).removeAttr('hidden');
    $('#declarationContainer-' + personIndex).show();
}
function hideDeclaration(personIndex) {
    $('#declarationContainer-' + personIndex).attr('hidden', true);
    $('#declarationContainer-' + personIndex).hide();
}