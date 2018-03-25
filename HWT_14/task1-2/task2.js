function calc(){
    subtask2(document.getElementById("calc").value);
}

function subtask2(str) {
	str = str.replace(/\s/g, "");
    var numbers = str.split(/[\+ \- \* \/ =]/g);
	console.log(numbers);
    var operations = [].concat(str.match(/[\+ \- \* \/ =]/g));
	console.log(operations);
    var result = parseFloat(numbers[0]);
	console.log(result);
    for (var i = 0; i < operations.length; i++)
    {
		console.log(operations[i]);
		console.log(numbers[i+1]);
        switch (operations[i])
        {
            case '+':
                result = +result + numbers[i + 1];
                break;
            case '-':
                result = +result - numbers[i + 1];
                break;
            case "*":
                result = +result * numbers[i + 1];
                break;
            case "/":
                result = +result / numbers[i + 1];
                break;
			default:
				break;
        }
    }
	
	
    //я не понимаю, че происходит вроде все нормально, а выдает непонятно что
	document.getElementById("result2").innerHTML = result;
}
