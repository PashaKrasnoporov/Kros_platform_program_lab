import React, {FC, PropsWithChildren} from 'react';
import {Route, Routes, Navigate} from 'react-router-dom';
import {useAuth0} from "@auth0/auth0-react";
import AppRoutes from './AppRoutes';
import { Navbar } from './components';

const ProtectedRoute: FC<PropsWithChildren> = (props) => {
    const {isAuthenticated} = useAuth0();
    return <>
        {isAuthenticated ? props.children : <Navigate to="/" replace/>}
    </>;
}

const App: React.FC = () => {
    return (
      <div className='container mx-auto'>
          <Navbar/>
          <Routes>
              {AppRoutes.map((route, index) => {
                  const {element, secure, ...rest} = route;
                  return <Route
                    key={index}
                    {...rest}
                    element={secure ? <ProtectedRoute>{element}</ProtectedRoute> : element}
                  />;
              })}
          </Routes>
      </div>
    );
};

export default App;