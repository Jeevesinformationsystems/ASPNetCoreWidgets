// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ajaxError(function (event, jqxhr, settings, thrownError) {
    if (jqxhr.status === 500) {
        //Internal server error. Display popup with OK button.  
        var problemDetail = JSON.parse(jqxhr.responseText);
    } else if (jqxhr.status === 401) {
        //Redirect to login page.    
    } else if (jqxhr.status === 400) {
        //Not found    
    }
});


function refreshWidget(widgetName) {
    $("#" + widgetName).load("/Widgets/index/" + widgetName);
}

$(function () {
    
    refreshWidget("Widget1");
    refreshWidget("Widget2");
});
