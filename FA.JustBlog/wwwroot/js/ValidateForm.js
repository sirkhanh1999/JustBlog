// add the rule here

// hàm validate
// Wait for the DOM to be ready
$(
    function () {
        // Initialize form validation on the registration form.
        // It has the name attribute "registration"
        $("form[id='form-create-post']").validate({
            // Specify validation rules
            rules: {
                // The key name on the left side is the name attribute
                // of an input field. Validation rules are defined
                // on the right side
                Title: {
                    required: true,
                },
                ShortDescription: {
                    required: true,
                },
                PostContent: {
                    required: true
                },

                //Published: { // <- NAME of every radio in the same group
                //    required: true
                //}
            },
            // Specify validation error messages
            messages: {
                Title: {
                    required: "The Title should not be blank",
                },
                ShortDescription: {
                    required: "The Short Description should not be blank",
                },
                PostContent: {
                    required: "The Post Content should not be blank"
                },
                //Published: { // <- NAME of every radio in the same group
                //    required: "Published should not be true or false"
                //}
            },
            // Make sure the form is submitted to the destination defined
            // in the "action" attribute of the form when valid
            submitHandler: function (form) {
                form.prevenDefault();
                // form.submit();
            }
        });
    }
);