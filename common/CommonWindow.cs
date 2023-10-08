using System;
using Godot;

namespace GameCommon;

public class CommonWindow {
    public Vector2I normalizedCurrentStep = new(0, 0);

    private readonly Window _window;
    private Vector2I? _targetPosition = null;
    private float _targetSpeed = 0.5f;
    private InterpolationType _targetInterpolation = InterpolationType.Linear;

    public CommonWindow(Window _window) {
        this._window = _window;
    }

    public void Process(double delta) {
       switch(_targetInterpolation) {
           case InterpolationType.Constant:
               ProcessConstantMove(delta);
               break;
       }
    }

    public void MoveConstantWindow(int x, int y, float speed = 10f) {
        _targetPosition = new Vector2I(x, y);
        _targetSpeed = speed;
        _targetInterpolation = InterpolationType.Constant;
    }

    public static void MakeTransparent(SceneTree tree, int windowId = 0) {
        tree.Root.TransparentBg = true;
		DisplayServer.WindowSetFlag(DisplayServer.WindowFlags.Transparent, true, windowId);
    }

    public static void GetRandomWindowPosition(out Vector2I position) {
        Vector2I screenSize = DisplayServer.ScreenGetSize();
        int x = GD.RandRange(0, screenSize.X);
        int y = GD.RandRange(0, screenSize.Y);

        position = new Vector2I(x, y);
    }

    private void ProcessConstantMove(double delta) {
        if (_targetPosition == null) return;

        Vector2I currentPosition = _window.Position;
        Vector2 direction = _targetPosition.Value - currentPosition;
        Vector2 step = direction * (float)(_targetSpeed * delta);

        normalizedCurrentStep = new(Math.Clamp((int)step.X, -1, 1), Math.Clamp((int)step.Y, -1, 1));
        Vector2I newPosition = currentPosition + normalizedCurrentStep;
        
        _window.Position = newPosition;

        if(_window.Position == _targetPosition.Value) {
            _targetPosition = null;
        }
    }
}