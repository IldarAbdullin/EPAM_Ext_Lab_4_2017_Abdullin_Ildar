function words () {
			var symbol = document.getElementById("string").value;
			//var symbol = string.split('');
			exceptions = [];
			sign = ['!', '?', ';', ':', ',', '.',' ', '\t'];
			for (var i = 0; i < symbol.length; i++) 
			{
				if (sign.indexOf(symbol[i]) != -1)
				{
					symbol[i] = "-"
				}
			}
			//symbol.join('*');
			//console.log(symbol);
			for (var i = 0; i < symbol.length; i++) 
			{
				for (var j = 0; j < symbol.length; j++)
				{
					if ((symbol[i] == symbol[j]) && (symbol[i] != " ") && (symbol[i] != "-") && (i != j))
					{
						
						if (exceptions.indexOf(symbol[i]) == -1)
						{
							exceptions.push(symbol[i]);
						}
					}
				}
				
			}
			//console.log(exceptions);
			symbol = symbol.replace("-"," ")			
			for (var k = 0; k < exceptions.length; k++)
			{
				var up = exceptions[k].toUpperCase();
				var low = exceptions[k].toLowerCase();
				
				while ((symbol.indexOf(up) != -1) || (symbol.indexOf(low) != -1))
				{ 					
					symbol = symbol.replace(up, ""); 
					symbol = symbol.replace(low, "");
				}
			}
			
			//console.log(symbol);
			//alert(words("Мама мыла раму"); //symbol.join('');
			document.getElementById("result1").innerHTML = symbol //.join('');
		}