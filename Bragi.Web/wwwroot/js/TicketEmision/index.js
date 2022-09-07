



const saveTicketAsPdf = function(id, name = "") {
    domtoimage.toPng(document.getElementById(id))
        .then(function (blob) {
            var pdf = new jsPDF('l', 'pt', [$(`#${id}`).width(), $(`#${id}`).height()]);
            pdf.addImage(blob, 'PNG', 0, 0, $(`#${id}`).width(), $(`#${id}`).height());
            pdf.save(`ticket-${name}.pdf`);
            that.options.api.optionsChanged();
        });
};