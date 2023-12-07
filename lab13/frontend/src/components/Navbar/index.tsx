import React from 'react';
import { Link } from 'react-router-dom';
import { useAuth0 } from "@auth0/auth0-react";

export const Navbar: React.FC = () => {
  const {
    loginWithRedirect,
    logout,
    isLoading,
    isAuthenticated
  } = useAuth0();

  return (
    <header className='mb-12'>
      <nav className='flex justify-between items-center text-xl border-black border-b-2 h-20'>
       <div className='flex items-center'>
         <Link to="/" className='text-[green] font-bold mr-5'>
           Лабораторна 13
         </Link>
         <Link to="/" className='ml-5'>
           Home
         </Link>
       </div>
        <div className='flex items-center'>
          {isAuthenticated && !isLoading ? (
            <>
              <Link to="/lab1">
                Lab 1
              </Link>
              <Link to="/lab2" className='ml-5'>
                Lab 2
              </Link>
              <Link to="/lab3" className='ml-5'>
                Lab 3
              </Link>
              <button onClick={() => logout()} className='ml-5'>
                Logout
              </button>
            </>
          ) : (
            <button onClick={() => loginWithRedirect()}>
              Login
            </button>
          )}
        </div>
      </nav>
    </header>
  );
};
