package main

import (
	"bufio"
	"fmt"
	"os"
	"strconv"
	"strings"

	rl "github.com/gen2brain/raylib-go/raylib"
)

var ColorPalette = []rl.Color{
	rl.NewColor(0x0B, 0x0B, 0x0C, 0x00), // 0 - Transparent
	rl.NewColor(0x1E, 0x2A, 0x3A, 0xFF), // 1 - Deep Blue
	rl.NewColor(0x52, 0x2B, 0x4F, 0xFF), // 2 - Deep Purple
	rl.NewColor(0x0B, 0x5A, 0x42, 0xFF), // 3 - Deep Green
	rl.NewColor(0x8F, 0x4A, 0x32, 0xFF), // 4 - Warm Brown
	rl.NewColor(0x5A, 0x58, 0x52, 0xFF), // 5 - Dark Gray
	rl.NewColor(0xC7, 0xC8, 0xCC, 0xFF), // 6 - Light Gray
	rl.NewColor(0xFF, 0xF4, 0xE6, 0xFF), // 7 - Soft White
	rl.NewColor(0xFF, 0x2D, 0x55, 0xFF), // 8 - Vivid Red
	rl.NewColor(0xFF, 0x9A, 0x32, 0xFF), // 9 - Warm Orange
	rl.NewColor(0xFF, 0xE7, 0x66, 0xFF), // 10 - Warm Yellow
	rl.NewColor(0x25, 0xE0, 0x6D, 0xFF), // 11 - Bright Green
	rl.NewColor(0x6A, 0xD7, 0xE4, 0xFF), // 12 - Custom Blue
	rl.NewColor(0x9A, 0x8D, 0xBB, 0xFF), // 13 - Soft Lavender
	rl.NewColor(0xFF, 0x7F, 0xB7, 0xFF), // 14 - Bright Pink
	rl.NewColor(0xFC, 0xD2, 0xB8, 0xFF), // 15 - Peach
}

const (
	SpriteWidth       int32 = 22
	SpriteHeight      int32 = 24
	PixelsPerTile     int32 = 8
	SpriteTotalWidth  int32 = SpriteWidth * PixelsPerTile
	SpriteTotalHeight int32 = SpriteHeight * PixelsPerTile
)

func _spriteDataToImage(data [SpriteTotalWidth][SpriteTotalHeight]int) rl.Texture2D {
	img := rl.GenImageColor(int(SpriteTotalWidth), int(SpriteTotalHeight), rl.NewColor(0x0B, 0x0B, 0x0C, 0x00))

	for x := 0; x < int(SpriteTotalWidth); x++ {
		for y := 0; y < int(SpriteTotalHeight); y++ {
			index := data[x][y]
			if index < 0 || index >= len(ColorPalette) {
				index = 0
			}
			color := ColorPalette[index]
			rl.ImageDrawPixel(img, int32(x), int32(y), color)
		}
	}

	tex := rl.LoadTextureFromImage(img)
	rl.UnloadImage(img)

	return tex
}

func _saveSprite(data [SpriteTotalWidth][SpriteTotalHeight]int) {
	file, err := os.Create("sprite.txt")
	if err != nil {
		return
	}
	defer file.Close()

	writer := bufio.NewWriter(file)
	for y := 0; y < int(SpriteTotalHeight); y++ {
		var line []string
		for x := 0; x < int(SpriteTotalWidth); x++ {
			line = append(line, strconv.Itoa(data[x][y]))
		}
		_, err := writer.WriteString(strings.Join(line, " ") + "\n")
		if err != nil {
			return
		}
	}

	writer.Flush()
}

func _readSprite() ([SpriteTotalWidth][SpriteTotalHeight]int, error) {
	var newData [SpriteTotalWidth][SpriteTotalHeight]int
	file, err := os.Open("sprite.txt")
	if err != nil {
		return newData, err
	}
	defer file.Close()

	scanner := bufio.NewScanner(file)
	y := 0
	for scanner.Scan() {
		if y >= int(SpriteTotalHeight) {
			break
		}
		fields := strings.Fields(scanner.Text())
		for x := 0; x < int(SpriteTotalWidth) && x < len(fields); x++ {
			value, err := strconv.Atoi(fields[x])
			if err != nil {
				return newData, err
			}
			newData[x][y] = value
		}
		y++
	}

	if err := scanner.Err(); err != nil {
		return newData, err
	}

	return newData, nil
}

func _drawTexture(texture rl.Texture2D, posX int32, posY int32) {
	rl.DrawTexture(texture, posX, posY, rl.White)
}

func _drawText(text string, posX int32, posY int32, col int) {
	rl.DrawText(text, posX, posY, 8, ColorPalette[col])
}

func _drawRectangle(posX int32, posY int32, width int32, height int32, col int) {
	rl.DrawRectangle(posX, posY, width, height, ColorPalette[col])
}

func _drawRectangleLines(posX int32, posY int32, width int32, height int32, col int) {
	_drawLine(posX+1, posY, posX+width-1, posY, col)
	_drawLine(posX, posY+height, posX+width, posY+height-1, col)
	_drawLine(posX+1, posY, posX, posY+height, col)
	_drawLine(posX+width, posY, posX+width, posY+height-1, col)
}

func _drawLine(startPosX int32, startPosY int32, endPosX int32, endPosY int32, col int) {
	rl.DrawLine(startPosX, startPosY, endPosX, endPosY, ColorPalette[col])
}

func _drawCircle(posX int32, posY int32, radius float32, col int) {
	rl.DrawCircle(posX, posY, radius, ColorPalette[col])
}

func _drawCircleLines(posX int32, posY int32, radius float32, col int) {
	rl.DrawCircleLines(posX, posY, radius, ColorPalette[col])
}

// CheckCollisionRecs - Check collision between two rectangles
func _checkCollisionRecs(rec1 rl.Rectangle, rec2 rl.Rectangle) bool {
	return rl.CheckCollisionRecs(rec1, rec2)
}

func _checkCollisionPointRec(point rl.Vector2, rec rl.Rectangle) bool {
	return rl.CheckCollisionPointRec(point, rec)
}

func _debug(a ...any) {
	fmt.Println(a)
}

func _toString(n int) string {
	return strconv.Itoa(n)
}

var targetKeys = []int32{
	rl.KeyUp,
	rl.KeyDown,
	rl.KeyLeft,
	rl.KeyRight,
	rl.KeyZ,
	rl.KeyX,
	rl.KeyC,
}

func _isKeyJustPressed(i int8) bool {
	return rl.IsKeyPressed(targetKeys[i])
}

func _isKeyPressed(i int8) bool {
	return rl.IsKeyDown(targetKeys[i])
}

func _isSaveJustPressed() bool {
	return rl.IsKeyPressed(rl.KeyR) && (rl.IsKeyDown(rl.KeyLeftControl) || rl.IsKeyDown(rl.KeyRightControl))
}

func _isCopyJustPressed() bool {
	return rl.IsKeyPressed(rl.KeyC) && (rl.IsKeyDown(rl.KeyLeftControl) || rl.IsKeyDown(rl.KeyRightControl))
}

func _isPasteJustPressed() bool {
	return rl.IsKeyPressed(rl.KeyV) && (rl.IsKeyDown(rl.KeyLeftControl) || rl.IsKeyDown(rl.KeyRightControl))
}

func _getMouseScroll() int {
	wheel := rl.GetMouseWheelMove()
	if wheel > 0 {
		return 1
	} else if wheel < 0 {
		return -1
	}
	return 0
}

func _getMouseX() int32 {
	return (rl.GetMouseX() - int32(offset.X)) / int32(scale)
}

func _getMouseY() int32 {
	return (rl.GetMouseY() - int32(offset.Y)) / int32(scale)
}

func _isMouseLeftJustPressed() bool {
	return rl.IsMouseButtonPressed(rl.MouseLeftButton)
}

func _isMouseLeftPressed() bool {
	return rl.IsMouseButtonDown(rl.MouseLeftButton)
}

func _isMouseRightJustPressed() bool {
	return rl.IsMouseButtonPressed(rl.MouseRightButton)
}

func _isMouseRightPressed() bool {
	return rl.IsMouseButtonDown(rl.MouseRightButton)
}

func _normalize(x, y float32) (float32, float32) {
	direction := rl.Vector2{X: x, Y: y}
	if rl.Vector2Length(direction) > 0 {
		direction = rl.Vector2Normalize(direction)
	}
	return direction.X, direction.Y
}
