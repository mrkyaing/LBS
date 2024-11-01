function logout() {
    const swalWithBootstrapButtons = Swal.mixin({
        customClass: {
            confirmButton: "btn btn-success",
            cancelButton: "btn btn-danger"
        },
        buttonsStyling: false
    });

    swalWithBootstrapButtons.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonText: "Yes, logout!",
        cancelButtonText: "No, cancel!",
        reverseButtons: true
    }).then((result) => {
        if (result.isConfirmed) {
            // Perform the logout by sending a request to the server
            $.ajax({
                url: '/Identity/Account/Logout', // Make sure the URL matches the logout endpoint
                type: 'POST',
                data: {
                    __RequestVerificationToken: $('input[name="__RequestVerificationToken"]').val() // Add anti-forgery token if needed
                },
                success: function (response) {
                    swalWithBootstrapButtons.fire({
                        title: "Logged out!",
                        text: "You have been logged out from the system.",
                        icon: "success"
                    }).then(() => {
                        window.location.href = "@Url.Page(" / ", new { area = "" })"; // Redirect after logout
                    });
                },
                error: function (err) {
                    console.log('Error:', err);
                    alert('An error occurred while logging out.');
                }
            });
        } else if (result.dismiss === Swal.DismissReason.cancel) {
            swalWithBootstrapButtons.fire({
                title: "Cancelled",
                text: "You are still logged in :)",
                icon: "warning"
            });
        }
    });
}
