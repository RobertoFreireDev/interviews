package main

import (
	"math"

	rl "github.com/gen2brain/raylib-go/raylib"
)

const (
	virtualScreenWidth  int32 = 256
	virtualScreenHeight int32 = 192
)

var (
	running            = true
	scale   float32    = 1.0
	offset  rl.Vector2 // Top-left position to draw the scaled texture
)

func main() {
	defer rl.CloseWindow()
	rl.SetConfigFlags(rl.FlagWindowResizable | rl.FlagVsyncHint)
	rl.InitWindow(virtualScreenWidth, virtualScreenHeight, "Go-8")
	rl.SetTargetFPS(60)
	target := rl.LoadRenderTexture(virtualScreenWidth, virtualScreenHeight)
	rl.SetTextureFilter(target.Texture, rl.FilterPoint)
	_start()

	for running {
		running = !rl.WindowShouldClose()

		if rl.IsKeyPressed(rl.KeyF11) {
			if rl.IsWindowFullscreen() {
				rl.ToggleFullscreen()
				rl.RestoreWindow()
				rl.SetWindowSize(int(virtualScreenWidth), int(virtualScreenHeight))
			} else {
				// Enter fullscreen
				monitor := rl.GetCurrentMonitor()
				currentMonitorWidth := rl.GetMonitorWidth(monitor)
				currentMonitorHeight := rl.GetMonitorHeight(monitor)
				rl.SetWindowSize(currentMonitorWidth, currentMonitorHeight)
				rl.ToggleFullscreen()
			}
		}
		_update(rl.GetFrameTime())

		rl.BeginDrawing()
		rl.BeginTextureMode(target)
		rl.ClearBackground(rl.Black)
		_draw()
		rl.EndTextureMode()
		rl.ClearBackground(rl.Black)
		currentWindowWidth := float32(rl.GetScreenWidth())
		currentWindowHeight := float32(rl.GetScreenHeight())
		scaleX := currentWindowWidth / float32(target.Texture.Width)
		scaleY := currentWindowHeight / float32(target.Texture.Height)
		scale = float32(math.Floor(math.Min(float64(scaleX), float64(scaleY))))
		if scale < 1.0 {
			scale = 1.0
		}
		scaledWidth := float32(target.Texture.Width) * scale
		scaledHeight := float32(target.Texture.Height) * scale
		offsetX := float32(int32((currentWindowWidth - scaledWidth) * 0.5))
		offsetY := float32(int32((currentWindowHeight - scaledHeight) * 0.5))
		offset = rl.NewVector2(offsetX, offsetY)
		rl.DrawTexturePro(
			target.Texture,
			rl.NewRectangle(0.0, 0.0, float32(target.Texture.Width), float32(-target.Texture.Height)), // Source rect (flipped Y)
			rl.NewRectangle(offset.X, offset.Y, scaledWidth, scaledHeight),                            // Destination rect (scaled and offset)
			rl.NewVector2(0, 0), // Origin (no rotation)
			0.0,                 // Rotation
			rl.White,
		)
		rl.EndDrawing()
	}

	rl.UnloadRenderTexture(target)
}
