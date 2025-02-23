// src/ProjectList.js
import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom";

function ProjectList() {
    const [projects, setProjects] = useState([]);
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchProjects = async () => {
            try {
                const response = await fetch("http://localhost:5285/api/projects");
                if (!response.ok) {
                    throw new Error(`Server error: ${response.status} ${response.statusText}`);
                }
                const data = await response.json();
                setProjects(data);
            } catch (err) {
                setError(err.message);
            }
        };

        fetchProjects();
    }, []);

    return (
        <div>
            <h2>Projektlista</h2>
            {error ? (
                <p style={{ color: "red" }}>Fel: {error}</p>
            ) : (
                <ul>
                    {projects.map((project) => (
                        <li key={project.id}>
                            {project.projectName} - {project.status}{" "}
                            <Link to={`/edit/${project.id}`}>Redigera</Link>
                        </li>
                    ))}
                </ul>
            )}
            <Link to="/create">Skapa nytt projekt</Link>
        </div>
    );
}

export default ProjectList;
