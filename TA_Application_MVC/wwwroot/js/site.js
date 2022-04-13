// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// This code is from this video https://www.youtube.com/watch?v=aKrzBR32pKk
$(function () {

    var PlaceHolderHere = $('#PlaceHolderHere');
    $('button[data-toggle="ajax-modal"]').click(function (event) {
        
        var url = $(this).data('url');
        $.get(url).done(function (data) {
            PlaceHolderHere.html(data);
            PlaceHolderHere.find('.modal').modal('show');
        })
    })

    PlaceHolderHere.on('click', '[data-save="modal"]', function (event) {
        var form = $(this).parents('.modal').find('form');
        var actionUrl = form.attr("action");
        var sendData = form.serialize();
        $.post(actionUrl, sendData).done(function (data) {
            PlaceHolderHere.find('modal').modal('hide');

        })

    });
})