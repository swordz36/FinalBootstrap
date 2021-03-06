﻿function AuthorFormViewModel() {
    var self = this;

    self.saveCompleted = ko.observable(false);
    self.sending = ko.observable(false);

    self.creating = author.id == 0;

    self.author = {
        id: author.id,
        firstName : ko.observable(),
        lastName : ko.observable(),
        biography : ko.observable()
    };

    self.validateAndSave = function (form) {
        if (!$(form).valid())
            return false;

        self.sending(true);

        // include the anti forgery token
        self.author.__RequestVerificationToken = form[0].value;

        $.ajax({
            url: (self.IsCreating)?'Create':'Edit',
            type: 'post',
            contentType: 'application/x-www-form-urlencoded',
            data: ko.toJS(self.author),
            success: self.successfulSave,
            error: self.errorSave,
            complete: function () { self.sending(false) }

        })        
    };

    self.successfulSave = function () {
        self.saveCompleted(true);
        $('.body-content').prepend(
            '<div class="alert alert-success"><strong> Success!</strong> The new author has been saved.</div>');
        setTimeout(function () {
            if (self.IsCreating)
                location.href = './'
            else
                location.href = '../';
        }, 2500);
    };

    self.errorSave = function () {
        $('.body-content').prepend(
            '<div class="alert alert-danger"><strong> Error!</strong> There was an error saving the author.</div> ');
    };
}