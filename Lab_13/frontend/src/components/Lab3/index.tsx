import React, { useState } from 'react';
import { useAuth0 } from '@auth0/auth0-react';

export const Lab3: React.FC = () => {
  const { getAccessTokenSilently } = useAuth0();
  const [input, setInput] = useState<string>('');
  const [output, setOutput] = useState<string | null>(null);

  const runLab = async () => {
    const res = await fetch('https://127.0.0.1:7035/labs/3', {
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
      <h1 className="text-2xl font-bold">Lab 3</h1>

      <p>Example input:</p>
      <p>5 4 5 1</p>
      <p>1 2 3 4 5</p>
      <p>1 2 1</p>
      <p>2 3 10</p>
      <p>3 4 100</p>
      <p>4 5 100</p>

      <p className="mt-4">Expected response:</p>
      <p>1 0</p>
      <p>2 1</p>
      <p>3 11</p>
      <p>4 111</p>
      <p>5 211</p>

      <div className="flex flex-col gap-2 mt-4">
        <label htmlFor="lab3input">Enter input:</label>
        <textarea
          cols={50}
          rows={10}
          name="data"
          id="lab3input"
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
