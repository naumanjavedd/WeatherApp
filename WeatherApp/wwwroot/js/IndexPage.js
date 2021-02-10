$("#btn_Search").on("click", function () {
    loadCustomOverlay();
});
function loadCustomOverlay() {

    var customElement = $("<div> <img  src='/lib/loading.gif' /> </div>", {
        "css": {
            "border": "4px dashed gold",
            "font-size": "40px",
            "text-align": "center",
            "padding": "10px"
        },
        "class": "your-custom-class",
        "text": "please wait"
    });
    $.LoadingOverlay("show", {
        image: "",
        custom: customElement
    });
}