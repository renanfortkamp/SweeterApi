import React from 'react';
import RoutesPages from './pages/Routes/RoutesPages.js';
import Context from './pages/Context/Context.js';

function App() {
  return (
    <Context.Provider value="">
      <div className="App">
        <RoutesPages />
      </div>
    </Context.Provider>
  );
}

export default App;
