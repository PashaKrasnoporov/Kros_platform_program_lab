import React, { useState } from 'react';
import { useAuth0 } from '@auth0/auth0-react';

export const Lab2: React.FC = () => {
  const { getAccessTokenSilently } = useAuth0();
  const [input, setInput] = useState<string>('');
  const [output, setOutput] = useState<string | null>(null);

  const runLab = async () => {
    const res = await fetch('https://127.0.0.1:7035/labs/2', {
      body: input,
      method: 'POST',
      headers: {
        'Authorization': `Bearer ${await getAccessTokenSilently()}`,
        'Content-Type': 'text/plain'
      },
    });

    if (res.ok) {
      setOutput(await res.text());
    }
  };

  return (
    <div className="p-4">
      <h1 className="text-2xl font-bold">Lab 2</h1>

      <div className="w-1/2">
        <p>
          У прямокутній таблиці N×M (у кожній клітинці якої записано деяке число) на початку гравець перебуває у лівій верхній клітині.
          За один хід йому дозволяється переміщатися в сусідню клітину або праворуч, або вниз (ліворуч і вгору переміщатися заборонено).
          При проході через клітку з гравця беруть стільки у.о., скільки записано в цій клітці (гроші беруть також за першу і останню клітини його шляху).
          Потрібно знайти мінімальну суму у.о., заплативши яку гравець може потрапити у правий нижній кут.
        </p>
      </div>

      <p className="mt-4">Example input:</p>
      <p className="mb-1">3 4 (розмірність)</p>
      <p>1 1 1 1</p>
      <p>5 2 2 100</p>
      <p>9 4 2 1</p>
      <p className="mt-4">Expected response: 8</p>

      <div className="flex flex-col gap-2 mt-4 w-1/2">
        <label htmlFor="lab2input">Enter input:</label>
        <textarea
          cols={50}
          rows={10}
          name="data"
          id="lab2input"
          value={input}
          onChange={(e) => setInput(e.target.value)}
          className="border border-gray-400 p-2 rounded"
        ></textarea>
        <button
          onClick={runLab}
          className="bg-blue-500 hover:bg-blue-600 text-white font-bold py-2 px-4 rounded"
        >
          Submit
        </button>
      </div>

      {output !== null && (
        <div className="mt-5">
          <h2 className="text-xl font-bold">Response:</h2>
          <p>{output}</p>
        </div>
      )}
    </div>
  );
};
