//// Class definition
//var KTSelect2 = function() {
//    // Private functions
//    var demos = function() {
//        function formatRepo(repo) {
//            if (!repo.ID) return repo.TEXT;
//            var markup = "<div class='select2-result-repository clearfix'>" +
//                "<div class='select2-result-repository__meta'>" +
//                "<div class='select2-result-repository__title'>" + repo.TEXT + "</div>";
//            markup += "</div>"; markup += "</div>";
//            return markup;
//        }

//        function formatRepoSelection(repo) {
//             console.log(repo.ID)
//           // return;
//            return repo.TEXT || repo.ID;
//        }

//        $("#emp_name_select2").select2({
//            placeholder: "Search for git repositories",
//            allowClear: true,
//            ajax: {
//                url: GetEmployees_by_name,
//                dataType: 'json',
//                delay: 250,
//                data: function(params) {
//                    return {
//                        q: params.term, // search term
//                        page: params.page
//                    };
//                },
//                processResults: function(data, params) {
//                    // parse the results into the format expected by Select2
//                    // since we are using custom formatting functions we do not need to
//                    // alter the remote JSON data, except to indicate that infinite
//                    // scrolling can be used
//                    params.page = params.page || 1;

//                    return {
//                        results: $.parseJSON(data),
//                        pagination: {
//                            more: (params.page * 30) < data.total_count
//                        }
//                    };
//                },
//                cache: true
//            },
//            escapeMarkup: function(markup) {
//                return markup;
//            }, // let our custom formatter work
//            minimumInputLength: 1,
//          //  templateResult: formatRepo, // omitted for brevity, see the source of this page
//          //  templateSelection: formatRepoSelection // omitted for brevity, see the source of this page
//        });

//        // custom styles

//        // tagging support
//        $('#kt_select2_12_1, #kt_select2_12_2, #kt_select2_12_3, #kt_select2_12_4').select2({
//            placeholder: "Select an option",
//        });

//        // disabled mode
//        $('#kt_select2_7').select2({
//            placeholder: "Select an option"
//        });

//        // disabled results
//        $('#kt_select2_8').select2({
//            placeholder: "Select an option"
//        });

//        // limiting the number of selections
//        $('#kt_select2_9').select2({
//            placeholder: "Select an option",
//            maximumSelectionLength: 2
//        });

//        // hiding the search box
//        $('#kt_select2_10').select2({
//            placeholder: "Select an option",
//            minimumResultsForSearch: Infinity
//        });

//        // tagging support
//        $('#kt_select2_11').select2({
//            placeholder: "Add a tag",
//            tags: true
//        });

//        // disabled results
//        $('.kt-select2-general').select2({
//            placeholder: "Select an option"
//        });
//    }

//    var modalDemos = function() {
//        $('#kt_select2_modal').on('shown.bs.modal', function () {
//            // basic
//            $('#kt_select2_1_modal').select2({
//                placeholder: "Select a state"
//            });

//            // nested
//            $('#kt_select2_2_modal').select2({
//                placeholder: "Select a state"
//            });

//            // multi select
//            $('#kt_select2_3_modal').select2({
//                placeholder: "Select a state",
//            });

//            // basic
//            $('#kt_select2_4_modal').select2({
//                placeholder: "Select a state",
//                allowClear: true
//            }); 
//        });
//    }

//    // Public functions
//    return {
//        init: function() {
//            demos();
//            modalDemos();
//        }
//    };
//}();

//// Initialization
//jQuery(document).ready(function() {
//    KTSelect2.init();
//});