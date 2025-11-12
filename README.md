# SimDash - Unity Arduino Car Simulation

This project connects a Unity car game with Arduino Uno to display speed on a 4-digit 7-segment display and control a fan motor.

## Components

- **Unity**: Simple car game with steering wheel input
- **Arduino Uno**: 7-segment display and motor control

## Hardware Setup

1. Connect 4-digit 7-segment display to Arduino:
   - CLK pin to digital pin 2
   - DIO pin to digital pin 3
   - VCC to 5V
   - GND to GND

2. Connect 5V motor to Arduino:
   - Motor positive to digital pin 9 (PWM)
   - Motor negative to GND (via transistor if needed for higher current)

3. Connect Arduino to computer via USB for serial communication.

## Software Setup

### Arduino

1. Install TM1637 library in Arduino IDE (Sketch > Include Library > Manage Libraries > Search for TM1637)
2. Upload `ArduinoCode/simdash.ino` to Arduino Uno
3. Note the COM port (e.g., COM3 on Windows, /dev/ttyACM0 on Linux)

### Unity

1. Open the project in Unity (2020+ recommended)
2. In `SerialCommunicator.cs`, update `portName` to match your Arduino port (e.g., "COM3" for Windows or "/dev/ttyACM0" for Linux)
3. Open the `Assets/Scenes/CarDrivingScene.unity` scene
4. The scene includes:
   - **Car**: A cube with CarController and Rigidbody components
   - **Ground**: A large plane for driving
   - **Main Camera**: Positioned above and behind for a good view
   - **Directional Light**: Provides scene lighting
   - **GameManager**: Contains SerialCommunicator for Arduino connection

## Running the Project

1. Upload Arduino code and note the port
2. Open Unity project
3. Run the scene
4. Use steering wheel to control car
5. Speed will be sent to Arduino, updating display and fan

## Notes

- Speed is scaled 0-100 for display
- Motor PWM is mapped from speed
- Ensure serial port permissions on Linux/Mac

## MCP Usage

This project supports the Model Context Protocol (MCP) for enhanced Unity development with AI assistants. MCP allows tools like GitHub Copilot to interact directly with Unity's editor and project structure.

### Setup MCP Server

1. Install the Unity MCP package:
   - Follow instructions at [Unity MCP GitHub](https://github.com/CoplayDev/unity-mcp) to set up the MCP server on your machine.
2. Configure VS Code:
   - Ensure you have the MCP support enabled in your VS Code setup.
   - Update the path in `.vscode/mcp.json` if your Unity MCP installation differs:
     - Linux: `/home/YOUR_USERNAME/.local/share/UnityMCP/UnityMcpServer/src`
     - Windows: `C:\\Users\\YOUR_USERNAME\\AppData\\Local\\UnityMCP\\UnityMcpServer\\src`
   - Do not commit your personal paths to version control!

3. Start the MCP server:
   - Open Unity and ensure the project is loaded
   - The MCP server will automatically connect when you use compatible AI tools
