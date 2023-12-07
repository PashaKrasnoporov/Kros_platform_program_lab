import React from 'react';

export const Home: React.FC = () => {
  return (
    <div>
      <h1 className="mt-5 text-2xl font-bold">Welcome</h1>
      <p className="mt-3 leading-6 text-gray-700">
        Цей веб-додаток розроблено з використанням ASP.NET Core web API і складається з двох проектів:
      </p>
      <ol className="list-decimal list-inside mt-3 ml-5">
        <li className="mb-2">
          <strong>Веб-додаток:</strong> Основний веб-додаток ASP.NET Core web API та фронтенд частина на ReactJS.
        </li>
        <li className="mb-2">
          <strong>Бібліотека класів:</strong> Бібліотека класів, яка дозволяє виконувати практичні завдання (1, 2 або 3).
        </li>
      </ol>
      <h2 className="mt-5 text-2xl font-bold">Розгортання</h2>
      <p className="mt-3 leading-6 text-gray-700">
        Додаток (.net core web api) буде розгорнуто на операційній системі Linux (Ubuntu/Debian) за допомогою віртуальної машини.
      </p>
      <h2 className="mt-5 text-2xl font-bold">Інтерфейс користувача</h2>
      <p className="mt-3 leading-6 text-gray-700">
        Інтерфейс користувача включає наступні сторінки:
      </p>
      <ul className="list-disc list-inside mt-3 ml-5">
        <li className="mb-2">Домашня сторінка із описом проекту.</li>
        <li className="mb-2">Сторінки входу, реєстрації та профілю користувача (Okta auth).</li>
        <li className="mb-2">Три сторінки для кожної підпрограми з полями для вводу та виводу та описом завдання.</li>
      </ul>
      <p className="mt-3 leading-6 text-gray-700">
        Доступ до сторінок з підпрограмами можливий після автентифікації.
      </p>
      <p className="mt-3 leading-6 text-gray-700">
        Аутентифікація та авторизація реалізовані за допомогою OAuth2 із вибраним провайдера сервера OAuth2:
      </p>
      <ul className="list-disc list-inside mt-3 ml-5">
        <li className="mb-2">Okta oauth (доступна версія для розробників).</li>
      </ul>
      <span className="block mt-5 text-sm text-gray-600">Sincerely, ushkoff.</span>
    </div>
  );
}