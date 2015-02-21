function getQueryVariable(variable)  //Sätter fokus på bilden man tryckt på
{
    var query = window.location.search.substring(1);
    var vars = query.split("&");

    for (var i = 0; i < vars.length; i++)
    {
        var pair = vars[i].split("=");
        if (pair[0] == variable)
        {
            return pair[1];
        }
    }
    return (false);
}

var imglink = getQueryVariable("Picture");
var pictureClass = document.getElementsByClassName(imglink)[0].setAttribute("class", "imageBorder");

document.getElementById("CloseMessage").onclick = function ()// Tar bort medlande som visas efter att man lyckat lada upp bild 
{
    document.getElementById("Close").innerHTML = "";
    return false;
};