var selectedPage;
var _totalCount;
var _perPage;
function getpage(page) {
    paginate(page);
}
function paginate(page, perPage, totalCount) {
    selectedPage = page;
    if (perPage) {
        _perPage = perPage;
    }
    if (totalCount) {
        _totalCount = totalCount;
    }
    //Flip page of results
    $('.tr-course').each(function () {
        $(this).hide();
    });
    for (var i = (page - 1) * _perPage; i < (_perPage * page) && i < _totalCount; i++) {
        $("#courseTable tbody tr[row-id='" + i + "']").show();
    }
    //Adjust paginator
    $('#paginationul').empty();
    var ul = document.getElementById('paginationul');
    var li = document.createElement('li');
    var span = document.createElement('span');
    var a = document.createElement('a');
    a.setAttribute('href', '#');
    a.setAttribute('onclick', 'getpage(1)')
    span.appendChild(document.createTextNode(String.fromCharCode(171)));
    a.appendChild(span);
    li.appendChild(a);
    ul.appendChild(li);

    var lastpage = 1;
    if (Math.ceil(_totalCount / _perPage) <= 10) {
        for (var i = 1; i <= Math.ceil(_totalCount / _perPage) && i <= 10; i++) {
            var li = document.createElement('li');
            var a = document.createElement('a');
            a.setAttribute('href', '#top');
            if (selectedPage == i) {
                li.setAttribute('class', 'active');
            } else {
                a.setAttribute('onclick', "getpage(" + i + ")");
            }
            a.appendChild(document.createTextNode(i));
            li.appendChild(a);
            ul.appendChild(li);
            lastpage++;
        }
    } else {
        for (var i = (selectedPage > 5) ? (selectedPage - 5) : 1; i <= Math
            .ceil(_totalCount / _perPage)
            && (i <= ((selectedPage > 5) ? (5 + selectedPage) : 10)); i++) {
            var li = document.createElement('li');
            var a = document.createElement('a');
            a.setAttribute('href', '#top');
            if (selectedPage == i) {
                li.setAttribute('class', 'active');
            } else {
                a.setAttribute('onclick', "getpage(" + i + ")");
            }
            a.appendChild(document.createTextNode(i));
            li.appendChild(a);
            ul.appendChild(li);
            lastpage++;
        }
    }
    var li = document.createElement('li');
    var span = document.createElement('span');
    var a = document.createElement('a');
    a.setAttribute('href', '#');
    a.setAttribute('onclick', "getpage(" + Math.ceil(_totalCount / _perPage)
        + ")");
    span.appendChild(document.createTextNode(String.fromCharCode(187)));
    a.appendChild(span);
    li.appendChild(a);
    ul.appendChild(li);
    $('#totalCount').html(_totalCount);
}