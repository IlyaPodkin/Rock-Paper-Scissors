import React from "react";
import Rock from "./../images/Rock.png";
import Scissors from "./../images/Scissors.png";
import Paper from "./../images/Paper.png";
import "./../styles/game-process.css";

const GameProcess = () => {
    return(
        <div className="command-conteiner">
            <button className="command"><img className="command" src={Rock} alt="Камень" /></button>
            <button className="command"><img className="command" src={Scissors} alt="Ножницы" /></button>
            <button className="command"><img className="command" src={Paper} alt="Бумага" /></button>
        </div>
    );
};
export default GameProcess;
