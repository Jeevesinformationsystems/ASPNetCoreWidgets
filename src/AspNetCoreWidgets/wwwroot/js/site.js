// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ajaxError(function (event, jqxhr, settings, thrownError) {

    //alert("  2");
    //return;
    //if (jqxhr.status === 500) {
    //    //Internal server error. Display popup with OK button.  
    //    var problemDetail = JSON.parse(jqxhr.responseText);
    //} else if (jqxhr.status === 401) {
    //    //Redirect to login page.    
    //} else if (jqxhr.status === 400) {
    //    //Not found    
    //}
});


function refreshWidget(widgetName) {
    var name = widgetName;
    var methodType = "Load";
    var msg = methodType + " " + widgetName;


    $("#" + widgetName).load("/Widgets/index/" + widgetName, function (response, status, jqXHR ) {
        if (status === "error") {
            onError(msg);
        }
        else {
            onSuccess(msg);
        }

        onComplete(msg);
    });
}

$(function () {
    var widgetName = "Widget23";
    var methodType = "GET";
    var msg = methodType + " " + widgetName;
    var a = $.ajax({
        type: methodType,
        url: "/Widgets/index/" + widgetName
    }).done(function (jqXHR, status) {
        onSuccess(msg);
    }).fail(function (jqXHR, status) {
        onError(msg);
    }).always(function (jqXHR, status) {
        onComplete(msg);
    });

    refreshWidget("Widget1");
    refreshWidget("Widget23");
});
function onSuccess(message) {
    alert(message + " onSuccess");
}
function onError(message) {
    alert(message + " onError");
}
function onComplete(message) {
    alert(message + " onComplete");
}
