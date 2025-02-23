// src/ProjectEdit.js
import React, { useState, useEffect } from "react";
import { useParams, useNavigate } from "react-router-dom";

function ProjectEdit() {
    const { id } = useParams();
    const navigate = useNavigate();
    const [project, setProject] = useState({ projectName: "", status: "" });
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchProject = async () => {
            try {
                const response = await fetch(`http://localhost:5285/api/projects/${id}`);
                if (!response.ok) {
                    throw new Error(`Server error: ${response.status}`);
                }
                const data = await response.json();
                setProject(data);
            } catch (err) {
                setError(err.message);
            }
        };
        fetchProject();
    }, [id]);

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const response = await fetch(`http://localhost:5285/api/projects/${id}`, {
                method: "PUT",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(project),
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
            <h2>Redigera projekt</h2>
            {error && <p style={{ color: "red" }}>Fel: {error}</p>}
            <form onSubmit={handleSubmit}>
                <label>
                    Projektnamn:
                    <input
                        type="text"
                        value={project.projectName}
                        onChange={(e) =>
                            setProject({ ...project, projectName: e.target.value })
                        }
                    />
                </label>
                <br />
                <label>
                    Status:
                    <input
                        type="text"
                        value={project.status}
                        onChange={(e) => setProject({ ...project, status: e.target.value })}
                    />
                </label>
                <br />
                <button type="submit">Spara ändringar</button>
            </form>
        </div>
    );
}

export default ProjectEdit;
