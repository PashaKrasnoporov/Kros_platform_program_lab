import { useState } from 'react';

function Lab3() {
  const [input, setInput] = useState("");
  const [output, setOutput] = useState("");

  const execute = async () => {
    try {
      	fetch(
			'http://127.0.0.1:5000/lab/lab3', 
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
		<h1>Лабораторна робота 3</h1>
		<p>
			треба побудувати спочатку невпорядковану послідовність чисел, переміщуючи фішки з нанесеними числами від 1 до 15 у квадраті 4×4. На основі цієї гри була розроблена інша – поле в ній лише 4×2 клітинки, на полі 7 фішок, але на фішках зображені літери англійського алфавіту та арабські цифри (на кожній фішці – один символ, але на різних фішках можуть бути однакові символи). Мета гри колишня - упорядкувати відповідно до зразка стартове розміщення фішок за мінімальну кількість ходів.	. <br /> <br />


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

export default Lab3;