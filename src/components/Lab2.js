import { useState } from 'react';

function Lab2() {
  const [input, setInput] = useState("");
  const [output, setOutput] = useState("");

  const execute = async () => {
    try {
		fetch(
			'http://127.0.0.1:5000/lab/lab2', 
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
		<h1>Лабораторна робота 2</h1>
		<p>
			Розглянемо послідовності довжини N, що складаються з 0 і 1. Потрібно написати програму, яка за заданим натуральним числом N визначає кількість тих з них, в яких жодні дві одиниці не стоять поруч. <br /><br />

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

export default Lab2;