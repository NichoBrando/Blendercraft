import './App.css';
import Unity, { UnityContext } from "react-unity-webgl";
import { useEffect } from 'react';

const unityContext = new UnityContext({
  loaderUrl: './Game/webgl.loader.js',
  dataUrl: "./Game/webgl.data",
  frameworkUrl: "./Game/webgl.framework.js",
  codeUrl: "./Game/webgl.wasm",
});

function App() {

  useEffect(function () {
    unityContext.on("canvas", function (canvas) {
      canvas.width = 720;
      canvas.height = 600;
    });
  }, []);

  return (
    <div className="App">
      <Unity 
        unityContext={unityContext}
      />
    </div>
  );
}

export default App;
