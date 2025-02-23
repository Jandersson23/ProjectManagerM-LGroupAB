// src/App.js
import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import ProjectList from "./ProjectList";
import ProjectCreate from "./ProjectCreate";
import ProjectEdit from "./ProjectEdit";

function App() {
    return (
        <Router>
            <div className="App">
                <h1>Project Manager</h1>
                <Routes>
                    {/* Huvudsidan: Lista alla projekt */}
                    <Route exact path="/" component={ProjectList} />
                    {/* Sida för att skapa ett nytt projekt */}
                    <Route path="/create" component={ProjectCreate} />
                    {/* Sida för att redigera ett befintligt projekt */}
                    <Route path="/edit/:id" component={ProjectEdit} />
                </Routes>
            </div>
        </Router>
    );
}

export default App;

