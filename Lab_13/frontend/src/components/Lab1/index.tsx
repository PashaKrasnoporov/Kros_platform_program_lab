import React, { useState } from 'react';
import { useAuth0 } from '@auth0/auth0-react';

export const Lab1: React.FC = () => {
  const { getAccessTokenSilently } = useAuth0();
  const [input, setInput] = useState<string>('');
  const [output, setOutput] = useState<string | null>(null);

  const runLab = async () => {
    const res = await fetch('https://127.0.0.1:7035/labs/1', {
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
      <h1 className="text-2xl font-bold">Lab 1</h1>

      <p>Example input: 111111111110011111111</p>
      <p>Expected response: 4</p>

      <div className="flex flex-col gap-2 items-start mt-4">
        <label htmlFor="lab1input">Enter input:</label>
        <input
          id="lab1input"
          type="text"
          name="data"
          maxLength={1000}
          value={input}
          onChange={(e) => setInput(e.target.value)}
          className="border border-gray-400 p-2 rounded"
        />
        <button
          className="bg-blue-500 hover:bg-blue-600 text-white font-bold py-2 px-4 rounded"
          onClick={runLab}
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
