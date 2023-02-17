$("#catalogPopup").css('opacity', 0);
$("#searchPopup").css('opacity', 0);
$("#CatalogLink").click(function () {
    $("#catalogPopup").css('opacity', 1  );
})
$("#searchLink").click(function () {
    $("#searchPopup").css('opacity', 1);
    $("#catalogPopup").css('z-index', 122);
})
$("#catalogPopup").mouseleave(function () {
    $("#catalogPopup").css('opacity', 0);
    $("#catalogPopup").css('z-index', 0);
})
$("#searchPopup").mouseleave(function () {
    $("#searchPopup").css('opacity', 0);
    $("#catalogPopup").css('z-index', 0);
})
        // Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
