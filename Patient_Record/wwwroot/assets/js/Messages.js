//Made by : Omar Alderawi
//date : 2015-5-5



var YES_LABEL = '<button class="btn btn-success" id="8c01681b-19ad-4978-93cc-47f7da80fbac"><span class="bootstrap-dialog-button-icon glyphicon glyphicon-ok"></span> ‰⁄„ </button>';
var NO_LABEL = '<button class="btn btn-danger" id="d1545c69-eb5e-407f-acb0-a256f9ad91a8"><span class="bootstrap-dialog-button-icon glyphicon glyphicon-remove"></span> ·« </button>';
//check if valid integer
function isInt(n) {
    return Number(n) === n && n % 1 === 0;
}

// return content of message body depends on icon type and the message
var GetMessageContent = function(icon_type, message) {

    icon = '';
    if (icon_type == 1)
        icon = '<span style="width: 50px; font-size: 30px; color: #5CB85C;" class="glyphicon glyphicon-ok-sign" aria-hidden="true"></span>';
    else if (icon_type == 2)
        icon = '<span style="width: 50px; font-size: 30px; color: #F0AD4E;" class="glyphicon glyphicon-info-sign" aria-hidden="true"></span>';
    else if (icon_type == 3)
        icon = '<span style="width: 50px; font-size: 30px; color: #D9534F;" class="glyphicon glyphicon-info-sign" aria-hidden="true"></span>';
    else
        icon = '<span style="width: 50px; font-size: 30px; color: #5CB85C;" class="glyphicon glyphicon-ok-sign" aria-hidden="true"></span>';

    var $content = $('<div class="msg-container"><div class="msg-thumb">' + icon + '</div>');
    $content.append('<div class="msg-content"><p>' + message + '</p></div></div>');
    return $content;
}

/* return message takes parameters
 message_id: the id of message 
 message_title : the title of message
 icon_type : 1(info) 2(explanation)
 callback : return value yes:1, no:0, cancel:3
*/



var GetMessage = function(message_id, callback) {
    var url = '/Messages/GetMessage';

    var message = '';
    var result = '';

    $.ajax({
        type: "GET",
        url: url,
        dataType: 'json',
        data: {
            message_id: message_id
        },
        contentType: 'application/json',
        success: function (data) {
            message_type = data[0];
            $(".jq-toast-wrap").remove();
            if (message_type == 1) {
                //$.toast({
                //    heading: '',
                //    text: data[1],
                //    position: 'top-center',
                //    loaderBg: '#fec107',
                //    icon: 'success',
                //    hideAfter: 5000,
                //    stack: 6
                //});
                toastr.options = {
                    "closeButton": true,
                    "debug": false,
                    "newestOnTop": true,
                    "progressBar": true,
                    "positionClass": "toast-top-center",
                    "preventDuplicates": false,
                    "showDuration": "300",
                    "hideDuration": "1000",
                    "timeOut": "5000",
                    "extendedTimeOut": "1000",
                    "showEasing": "swing",
                    "hideEasing": "linear",
                    "showMethod": "fadeIn",
                    "hideMethod": "fadeOut"
                };


                //toastr.warning(data[1]);
                toastr.success(data[1]);
                //toastr.info(data[1]);
                //toastr.error(data[1]);

            } else if (message_type == 2) {
                //$.toast({
                //    heading: '',
                //    text: data[1],
                //    position: 'top-center',
                //    loaderBg: '#f0c541',
                //    icon: 'warning',
                //    hideAfter: 5000,
                //    stack: 6
                //});

                toastr.options = {
                    "closeButton": true,
                    "debug": false,
                    "newestOnTop": true,
                    "progressBar": true,
                    "positionClass": "toast-top-center",
                    "preventDuplicates": false,
                    "showDuration": "300",
                    "hideDuration": "1000",
                    "timeOut": "5000",
                    "extendedTimeOut": "1000",
                    "showEasing": "swing",
                    "hideEasing": "linear",
                    "showMethod": "fadeIn",
                    "hideMethod": "fadeOut"
                };
           

                toastr.warning(data[1]);
                //toastr.success(data[1]);
                //toastr.info(data[1]);
                //toastr.error(data[1]);


            } else if (message_type == 3) {
                
                toastr.options = {
                    "closeButton": true,
                    "debug": false,
                    "newestOnTop": true,
                    "progressBar": true,
                    "positionClass": "toast-top-center",
                    "preventDuplicates": false,
                    "showDuration": "300",
                    "hideDuration": "1000",
                    "timeOut": "5000",
                    "extendedTimeOut": "1000",
                    "showEasing": "swing",
                    "hideEasing": "linear",
                    "showMethod": "fadeIn",
                    "hideMethod": "fadeOut"
                };


                toastr.error(data[1]);

            }
        },
        error: function() {
            GetErrorMessage(jqXHR, textStatus, errorThrown);
        }
    });

}

var GetMessage_C = function(message_id, message_concat, callback) {
    var url = Message_url2;

    var message = '';
    var result = '';

    $.ajax({
        type: "GET",
        url: url,
        dataType: 'json',
        data: {
            message_id: message_id,
            concat_meg: message_concat
        },
        contentType: 'application/json',
        success: function(data) {
            message_type = data[0];
            $(".jq-toast-wrap").remove();
            if (message_type == 1) {
                //$.toast({
                //    heading: '',
                //    text: data[1],
                //    position: 'top-center',
                //    loaderBg: '#fec107',
                //    icon: 'success',
                //    hideAfter: 5000,
                //    stack: 6
                //});
                toastr.options = {
                    "closeButton": true,
                    "debug": false,
                    "newestOnTop": true,
                    "progressBar": true,
                    "positionClass": "toast-top-center",
                    "preventDuplicates": false,
                    "showDuration": "300",
                    "hideDuration": "1000",
                    "timeOut": "5000",
                    "extendedTimeOut": "1000",
                    "showEasing": "swing",
                    "hideEasing": "linear",
                    "showMethod": "fadeIn",
                    "hideMethod": "fadeOut"
                };


                //toastr.warning(data[1]);
                toastr.success(data[1]);
                //toastr.info(data[1]);
                //toastr.error(data[1]);

            } else if (message_type == 2) {
                //$.toast({
                //    heading: '',
                //    text: data[1],
                //    position: 'top-center',
                //    loaderBg: '#f0c541',
                //    icon: 'warning',
                //    hideAfter: 5000,
                //    stack: 6
                //});

                toastr.options = {
                    "closeButton": true,
                    "debug": false,
                    "newestOnTop": true,
                    "progressBar": true,
                    "positionClass": "toast-top-center",
                    "preventDuplicates": false,
                    "showDuration": "300",
                    "hideDuration": "1000",
                    "timeOut": "5000",
                    "extendedTimeOut": "1000",
                    "showEasing": "swing",
                    "hideEasing": "linear",
                    "showMethod": "fadeIn",
                    "hideMethod": "fadeOut"
                };


                toastr.warning(data[1]);
                //toastr.success(data[1]);
                //toastr.info(data[1]);
                //toastr.error(data[1]);


            } else if (message_type == 3) {
                BootstrapDialog.show({
                    size: BootstrapDialog.SIZE_NORMAL,
                    title: Message_Danger_Title,
                    message: GetMessageContent(message_type, data[1]),
                    type: BootstrapDialog.TYPE_DANGER,
                    closable: false,
                    draggable: true,
                    buttons: [{
                        label: " " + YES_LABEL + " ",
                        icon: 'glyphicon glyphicon-ok',
                        cssClass: 'btn-success',
                        //    hotkey: 13, // Keycode of keyup event of key 'A' is 65.
                        action: function(dialogItself) {
                            dialogItself.close();
                            result = 1;
                            callback(result);
                        }
                    }, {
                        label: " " + NO_LABEL + " ",
                        icon: 'glyphicon glyphicon-remove',
                        cssClass: 'btn-danger',
                        //  hotkey: 27,
                        action: function(dialogItself) {
                            dialogItself.close();
                            result = 0;
                            callback(result);
                        }
                    }]

                });

            }
        },
        error: function() {
            GetErrorMessage(textStatus, errorThrown);
        }
    });

}

var GetMessage_Back_up = function(message_id, callback) {
    var url = Message_url;

    var message = '';
    var result = '';

    $.ajax({
        type: "GET",
        url: url,
        dataType: 'json',
        data: {
            message_id: message_id
        },
        contentType: 'application/json',
        success: function(data) {
            message_type = data[0];
            $(".jq-toast-wrap").remove();
            if (message_type == 1) {
                $.toast({
                    heading: '',
                    text: data[1],
                    position: 'top-center',
                    loaderBg: '#fec107',
                    icon: 'success',
                    hideAfter: 5000,
                    stack: 6
                });

            } else if (message_type == 2) {
                $.toast({
                    heading: '',
                    text: data[1],
                    position: 'top-center',
                    loaderBg: '#f0c541',
                    icon: 'warning',
                    hideAfter: 5000,
                    stack: 6
                });

            } else if (message_type == 3) {
                BootstrapDialog.show({
                    size: BootstrapDialog.SIZE_NORMAL,
                    title: Message_Danger_Title,
                    message: GetMessageContent(message_type, data[1]),
                    type: BootstrapDialog.TYPE_DANGER,
                    closable: false,
                    draggable: true,
                    buttons: [{
                        label: " " + YES_LABEL + " ",
                        icon: 'glyphicon glyphicon-ok',
                        cssClass: 'btn-success',
                        //    hotkey: 13, // Keycode of keyup event of key 'A' is 65.
                        action: function(dialogItself) {
                            dialogItself.close();
                            result = 1;
                            callback(result);
                        }
                    }, {
                        label: " " + NO_LABEL + " ",
                        icon: 'glyphicon glyphicon-remove',
                        cssClass: 'btn-danger',
                        //  hotkey: 27,
                        action: function(dialogItself) {
                            dialogItself.close();
                            result = 0;
                            callback(result);
                        }
                    }]

                });

            }
        },
        error: function() {
            GetErrorMessage(jqXHR, textStatus, errorThrown);
        }
    });

}





var GetErrorMessage = function(jqXHR, textStatus, errorThrown, type, callback) {


    if (jqXHR.status == 501) {
        $("#login_modal").modal("show");
        return false;
    }

    $(".jq-toast-wrap").remove();
    var errormsg = '';

    if (jqXHR.responseJSON) {
        errormsg = jqXHR.responseJSON.error ? "" + jqXHR.responseJSON.error : jqXHR.responseJSON;
    } else {
        errormsg = jqXHR.statusText ? jqXHR.statusText : 'Unknowen Error';
    }


    if (type == 3) {


        //$.toast({
        //    heading: '',
        //    text: errormsg,
        //    position: 'top-center',
        //    loaderBg: '#ed6f56',
        //    icon: 'error',
        //    hideAfter: 5000,
        //    stack: 6
        //});

        toastr.options = {
            "closeButton": true,
            "debug": false,
            "newestOnTop": true,
            "progressBar": true,
            "positionClass": "toast-top-center",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        };

        toastr.error(errormsg);

    } else if (type == 4) {
        BootstrapDialog.show({
            size: BootstrapDialog.SIZE_NORMAL,
            title: "Error Message",
            message: GetMessageContent(3, errormsg),
            type: BootstrapDialog.TYPE_DANGER,
            draggable: true,
            buttons: [{
                label: " " + OK_LABEL + " ",
                icon: 'glyphicon glyphicon-ok',
                cssClass: 'btn-success',
                //    hotkey: 13, // Keycode of keyup event of key 'A' is 65.
                action: function(dialogItself) {
                    dialogItself.close();
                    result = 1;
                    callback(result);
                }
            }, {
                label: CANCEL_LABEL,
                icon: 'glyphicon glyphicon-remove',
                cssClass: 'btn-danger',
                //  hotkey: 27,
                action: function(dialogItself) {
                    dialogItself.close();
                    result = 0;
                    callback(result);
                }
            }]

        });
    } else {

        //$.toast({
        //    heading: '',
        //    text: errormsg,
        //    position: 'top-center',
        //    loaderBg: '#ed6f56',
        //    icon: 'error',
        //    hideAfter: 5000,
        //    stack: 6
        //});

        toastr.options = {
            "closeButton": true,
            "debug": false,
            "newestOnTop": true,
            "progressBar": true,
            "positionClass": "toast-top-center",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        };

        toastr.error(errormsg);

    }

}