function deleteById(bookId) {
    try {
        Swal.fire({
            title: "Are you sure?",
            text: `You want to delete this book id ${bookId} .`,
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Yes, delete it!"
        }).then((result) => {
            if (result.isConfirmed) {
                // Perform the deletion by sending a request to the server
                $.ajax({
                    url: `/book/delete?id=${bookId}`,
                    type: 'POST',
                    success: function (response) {
                        if (response.success) {
                            Swal.fire({
                                title: "Deleted!",
                                text: "Your file has been deleted.",
                                icon: "success"
                            });
                            // Optionally reload the page or remove the row from the table
                            location.reload(); // This will refresh the page
                        }
                        else {
                            Swal.fire({
                                title: "Failed!",
                                text: "Failed to delete the record.",
                                icon: "error"
                            });
                        }
                    },
                    error: function (err) {
                        console.log('Error:', err);
                        alert('An error occurred while deleting the record.');
                    }
                });
            }
        });

    }
    catch (err) {
        console.log(err);
    }
} //end of deletedById

$('#bookTable').on('click', '.btn-danger', function () {
    const bookId = $(this).data('id');
    deleteById(bookId);
});
//setTimeout for "statusAlert" with 3 seconds = 3000 million seconds
setTimeout(function () {
    $('#statusAlert').fadeOut('slow');
}, 3000); // 3 seconds
$("#btnHi").on('click', function () {
    Swal.fire({
        icon: "error",
        title: "Oops...",
        text: "Something went wrong!",
        footer: '<a href="#">Why do I have this issue?</a>'
    });
});
