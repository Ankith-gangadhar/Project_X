import React from 'react';
import AnimatedProfit from './components/AnimatedProfit';

function App() {
  // Sample profit data - replace with your API data
  const profitData = 24500; 

  return (
    <div className="App">
      <h1>Project X Dashboard</h1>
      <AnimatedProfit profit={profitData} />
    </div>
  );
}

export default App;
