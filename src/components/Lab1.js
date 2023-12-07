import { useState } from 'react';

function Lab1() {
  const [input, setInput] = useState("");
  const [output, setOutput] = useState("");

  const execute = async () => {
    try {
		fetch(
			'http://127.0.0.1:5000/lab/lab1', 
			{
				method: "POST",
				headers: {
					'Content-Type': 'application/json'
				},
				body: JSON.stringify({"Input": input})
			}
		)
		.then(response => response.text())
		.then(text => setOutput(text));
    } catch (error) {
      console.error('Error fetching data:', error);
    }
  };

  return (
    <div>
		<h1>Лабораторна робота 1</h1>
		<p>
		   Дано рядок, що складається з N пар різних символів. Ви хочете відобразити всі перестановки символів у цьому рядку.Вводу <br /><br />
			Вхідні дані <br />
			У Вхідний файл INPUT.TXT містить рядок, що складається з N символів (1 ≤ N ≤ 8), символів - букв англійського алфавіту і цифр. <br/><br />
			Вихідні дані <br />
			У У вихідному файлі OUTPUT.TXT вивести по одній перестановці на кожен рядок. Перестановки можна зробити висновок в будь-якому порядку. Не повинно бути повторень і рядків, які не є перестановками вихідного..
		</p>
		<textarea
			value={input}
			onChange={(e) => setInput(e.target.value)}
			placeholder="Input"
			rows={5}
			/>
		<button onClick={execute}>Execute</button>
		{
			!output ? (
				<p/>
			) : (
				<p><b>Output:</b> {output}</p>
			)
		}
	</div>
  );
}

export default Lab1;