import { BrowserRouter, Route, Routes} from 'react-router-dom';
import { routes } from './routes';
import { Layout } from './components/Layout/Layout';
import React from 'react';

function App() {
  return (   
  <BrowserRouter>   
    <Layout>
        <Routes>
          {routes.map((route) => (
          <Route
            key={route.key}
            path={route.path}
            element={<route.component />}
          />
        ))}
        </Routes>
      
    </Layout>      
  </BrowserRouter>);
}

export default App;
