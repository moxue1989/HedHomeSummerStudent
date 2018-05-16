var selectedPage = 1;
var _totalCount=null
function getpage(page) {
    paginate(_totalCount,page);
}
function paginate(totalCount,page) {
    if (!_totalCount) {
        _totalCount = totalCount;
    }
    var perpage = 5;
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
    if (Math.ceil(_totalCount / perpage) <= 10) {
        for (var i = 1; i <= Math.ceil(_totalCount / perpage) && i <= 10; i++) {
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
            .ceil(_totalCount / perpage)
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
    a.setAttribute('onclick', "getpage(" + Math.ceil(_totalCount / perpage)
        + ")");
    span.appendChild(document.createTextNode(String.fromCharCode(187)));
    a.appendChild(span);
    li.appendChild(a);
    ul.appendChild(li);
    $('#totalCount').html(_totalCount);
}