function getQueryVariable(variable)
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

document.getElementById("CloseMessage").onclick = function ()
{
    document.getElementById("MessageWrapper").innerHTML = "";
    return false;
};