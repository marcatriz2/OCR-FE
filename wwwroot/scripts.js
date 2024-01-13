document.getElementById('upload-form').addEventListener('submit', function (e) {
    e.preventDefault();
    var fileInput = document.getElementById('id-file');
    var file = fileInput.files[0];
    // Add AJAX request to send the file to your backend
    // Additional JavaScript code remains the same
});
