// src/ProjectCreate.js
import React, { useState } from "react";
import { useNavigate } from "react-router-dom";

function ProjectCreate() {
    const [projectName, setProjectName] = useState("");
    const [error, setError] = useState(null);
    const navigate = useNavigate();

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const response = await fetch("http://localhost:5285/api/projects", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify({ projectName }),
            });
            if (!response.ok) {
                throw new Error(`Server error: ${response.status}`);
            }
            navigate("/");
        } catch (err) {
            setError(err.message);
        }
    };

    return (
        <div>
            <h2>Skapa nytt projekt</h2>
            {error && <p style={{ color: "red" }}>Fel: {error}</p>}
            <form onSubmit={handleSubmit}>
                <label>
                    Projektnamn:
                    <input
                        type="text"
                        value={projectName}
                        onChange={(e) => setProjectName(e.target.value)}
                    />
                </label>
                <button type="submit">Skapa</button>
            </form>
        </div>
    );
}

export default ProjectCreate;
