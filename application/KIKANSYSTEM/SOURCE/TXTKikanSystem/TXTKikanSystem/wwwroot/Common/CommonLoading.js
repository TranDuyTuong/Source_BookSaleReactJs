// modal loading
export function DomModalLoading() {
    var html = "";
    html += '<div class="modal" tabindex="-1" role="dialog" id="dialogLoading" style="background-color: #0000009e;">';
    html += '<div class="modal-dialog" role="document">';
    html += '<div class="modal-content" style="background: none; border: none;">';
    html += '<div class="modal-body" style="text-align: center">';
    html += '<div class="spinner-grow text-success" role="status" style="margin: 150px 10px;"></div>';
    html += '<div class="spinner-grow text-danger" role="status" style="margin: 150px 10px;"></div>';
    html += '<div class="spinner-grow text-warning" role="status" style="margin: 150px 10px;"></div>';
    html += '</div>';
    html += '</div>';
    html += '</div>';
    html += '</div>';
    return html;
};

export function ModalImportFile(header) {
    var html = "";
    html += '<div class="modal" tabindex="-1" id="dialogImport" style="background-color: #0000009e;">>';
    html += '<div class="modal-dialog">';
    html += '<div class="modal-content">';
    html += '<div class="modal-header">';
    html += '<h5 class="modal-title">' + header + '</h5>';
    html += '<button type="button" id="btn_CloseImportFile" style="background: none;border: none;color: red;font-weight: 600;">X</button>';
    html += '</div>';
    html += '<div class="modal-body">';
    html += '<div class="mb-3">';
    html += '<input style="color: black;border: none; " class="form-control" type="file" id="formFile">';
    html += '</div>';
    html += '</div>';
    html += '<div class="modal-footer">';
    html += '<button type="button" class="btn btn-primary"><i class="fas fa-plus-square"></i> Submit</button>';
    html += '</div>';
    html += '</div>';
    html += '</div>';
    html += '</div>';
    return html;
};