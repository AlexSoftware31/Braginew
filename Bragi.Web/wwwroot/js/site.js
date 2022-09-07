// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


/**catcha**/
var code;
function createCaptcha() {
    //clear the contents of captcha div first 
    document.getElementById('captcha').innerHTML = "";
    var charsArray =
        "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ@.#$%&";
    var lengthOtp = 6;
    var captcha = [];
    for (var i = 0; i < lengthOtp; i++) {
        var index = Math.floor(Math.random() * charsArray.length + 1); //get the next character from the array
        if (captcha.indexOf(charsArray[index]) === -1)
            captcha.push(charsArray[index]);
        else i--;
    }
    var canv = document.createElement("canvas");
    canv.id = "captcha";
    canv.width = 250;
    canv.height = 70;
    var ctx = canv.getContext("2d");
    ctx.font = "60px Roboto-bold";
    ctx.strokeText(captcha.join(""), 0, 50);
    code = captcha.join("");
    document.getElementById("captcha").appendChild(canv);
}
var ShowOrHide = (id) => {
    $(`#${id}`).toggle();
    $('#AcompanyNumber').val(0);
};

var GenerateQr = (code, id, size) => {
    var qr = new QRious({
        element: document.getElementById(id),
        value: code,
        size
    });
};

var printElement = (node) => {
    $(node).print();
};

/*end catcha**/