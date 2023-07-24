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