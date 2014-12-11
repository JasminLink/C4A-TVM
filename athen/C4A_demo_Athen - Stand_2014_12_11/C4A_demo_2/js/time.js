	function clock() {
		
	function GetDay(intDay){
		var DayArray = new Array("So", "Mo", "Di", "Mi", "Do", "Fr", "Sa");
		return DayArray[intDay];
		}
		
	var Datum = new Date();
	var Tag = Datum.getDate();
	var Monat = Datum.getMonth() + 1;
	var Jahr = Datum.getFullYear();
	var Stunden = Datum.getHours();
	var Minuten = Datum.getMinutes();
	var Sekunden = Datum.getSeconds();

	var strSekunden;
	var strMinuten;
		
	if(parseInt(Minuten)< 10 && Minuten.toString().length < 2)
        strMinuten = "0" + Minuten;
    else
        strMinuten=Minuten;
		
	if(parseInt(Sekunden)< 10 && Sekunden.toString().length < 2)
        strSekunden = "0" + Sekunden;
    else
        strSekunden=Sekunden;





	var Heute = GetDay(Datum.getDay())
	
	//document.getElementById("timeelement").innerHTML = "hello"+Tag + ", " + Jahr + " - " + Stunden + ":" + Minuten + ":" + Sekunden;
	document.getElementById("timeelement").innerHTML = Stunden + ":" + strMinuten + ":" + strSekunden;
	document.getElementById("dateelement").innerHTML = Tag + "." + Monat + "." + Jahr;
	document.getElementById("tageelement").innerHTML = Heute + ".";
	}


window.onload=function(){
setInterval("clock()", 1000)
}