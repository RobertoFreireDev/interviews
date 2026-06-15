package main

import (
	"fmt"

	rl "github.com/gen2brain/raylib-go/raylib"
)

// ----------------- Global variables ----------------

var (
	objects       []Object
	spriteSheet   *SpriteSheet   = NewSpriteSheet()
	colorSelector *ColorSelector = NewColorSelector()
	infoText      *TimedText     = NewTimedText(1.0, 0, 183, 7)
)

// ----------------- Sprite sheet ----------------

type SpriteSheet struct {
	Data                   [SpriteTotalWidth][SpriteTotalHeight]int
	img                    rl.Texture2D
	selectedIndex          int
	selectionSize          int32
	sizePerPixel           int32
	spritePosXBasedOnIndex int32
	spritePosYBasedOnIndex int32
	copiedSprite           [8][8]int // Assuming max selection size is 8x8
	hasCopied              bool
}

func NewSpriteSheet() *SpriteSheet {
	return &SpriteSheet{selectedIndex: 0, selectionSize: 8, spritePosXBasedOnIndex: 0, spritePosYBasedOnIndex: 0, sizePerPixel: 8}
}

func (s *SpriteSheet) Copy() {
	for x := int32(0); x < s.selectionSize; x++ {
		for y := int32(0); y < s.selectionSize; y++ {
			s.copiedSprite[x][y] = s.Data[s.spritePosXBasedOnIndex+x][s.spritePosYBasedOnIndex+y]
		}
	}
	s.hasCopied = true
}

func (s *SpriteSheet) Paste() bool {
	if !s.hasCopied {
		return false
	}

	for x := int32(0); x < s.selectionSize; x++ {
		for y := int32(0); y < s.selectionSize; y++ {
			s.Data[s.spritePosXBasedOnIndex+x][s.spritePosYBasedOnIndex+y] = s.copiedSprite[x][y]
		}
	}
	s.UpdateImage()

	return true
}

func (s *SpriteSheet) SetPixel(x int32, y int32, v int) {
	if x < 0 || x >= s.selectionSize || y < 0 || y >= s.selectionSize {
		return
	}

	absX := s.spritePosXBasedOnIndex + x
	absY := s.spritePosYBasedOnIndex + y
	if absX < 0 || absX >= SpriteTotalWidth || absY < 0 || absY >= SpriteTotalHeight {
		return
	}

	s.Data[absX][absY] = v
	s.UpdateImage()

}

func (s *SpriteSheet) UpdateImage() {
	s.img = _spriteDataToImage(s.Data)
}

func (s *SpriteSheet) SetSelectedIndex(idx int) {
	posX := (int32(s.selectedIndex) % SpriteWidth) * PixelsPerTile
	posY := (int32(s.selectedIndex) / SpriteWidth) * PixelsPerTile
	spriteSheet.selectionSize = 8
	spriteSheet.sizePerPixel = 8
	s.selectedIndex = idx
	s.spritePosXBasedOnIndex = posX
	s.spritePosYBasedOnIndex = posY
}

// ----------------- Sprite asset ----------------

type SpriteAsset struct {
	posX int32
	posY int32
}

func NewSpriteAsset() *SpriteAsset {
	return &SpriteAsset{posX: 80, posY: 0}
}

func (s *SpriteAsset) GetIndex(x int32, y int32) int {
	idx := -1
	if x >= s.posX && x < s.posX+SpriteTotalWidth && y >= s.posY && y < s.posY+SpriteTotalHeight {
		idx = int((x-s.posX)/PixelsPerTile + ((y-s.posY)/PixelsPerTile)*SpriteWidth)
	}

	return idx
}

func (s *SpriteAsset) Update(deltaTime float32) {
	mousePosX := _getMouseX()
	mousePosY := _getMouseY()

	if _isMouseLeftPressed() {
		idx := s.GetIndex(mousePosX, mousePosY)
		if idx >= 0 {
			spriteSheet.SetSelectedIndex(idx)
		}
	}

	if _isCopyJustPressed() {
		spriteSheet.Copy()
		infoText.Show("copied")
	}

	if _isPasteJustPressed() {
		if spriteSheet.Paste() {
			infoText.Show("pasted")
		}
	}
}

func (s *SpriteAsset) Draw() {
	_drawTexture(spriteSheet.img, s.posX, s.posY)

	_drawRectangle(0, 0, 80, 9, 12)
	_drawRectangle(0, 183, 80, 9, 12)
	_drawRectangleLines(0, 0, 256, 192, 12)
	_drawRectangle(80, 0, 1, 192, 12)
	txt := " S: " + _toString(spriteSheet.selectedIndex) + ". C: " + _toString(colorSelector.Color)
	_drawText(txt, 0, 0, 7)
	_drawRectangleLines(s.posX+spriteSheet.spritePosXBasedOnIndex, s.posY+spriteSheet.spritePosYBasedOnIndex, spriteSheet.selectionSize, spriteSheet.selectionSize, 7)
}

// ----------------- Sprite editor ----------------

type SpriteEditor struct {
	posX int32
	posY int32
}

func NewSpriteEditor() *SpriteEditor {
	return &SpriteEditor{posX: 8, posY: 16}
}

func (s *SpriteEditor) Update(deltaTime float32) {
	x := (_getMouseX() - s.posX) / spriteSheet.sizePerPixel
	y := (_getMouseY() - s.posY) / spriteSheet.sizePerPixel
	if _isMouseLeftPressed() {
		spriteSheet.SetPixel(x, y, colorSelector.Color)
	}

	posX := (int32(spriteSheet.selectedIndex) % SpriteWidth) * PixelsPerTile
	posY := (int32(spriteSheet.selectedIndex) / SpriteWidth) * PixelsPerTile
	scroll := _getMouseScroll()
	if scroll < 0 && spriteSheet.selectionSize < 32 && (posX+spriteSheet.selectionSize*2) <= SpriteTotalWidth && (posY+spriteSheet.selectionSize*2) <= SpriteTotalHeight {
		spriteSheet.selectionSize *= 2
		spriteSheet.sizePerPixel /= 2
	}
	if scroll > 0 && spriteSheet.selectionSize > 8 {
		spriteSheet.selectionSize /= 2
		spriteSheet.sizePerPixel *= 2
	}
}

func (s *SpriteEditor) Draw() {
	if spriteSheet.selectedIndex < 0 {
		return
	}

	_drawRectangleLines(s.posX-1, s.posY-1, 64+2, 64+2, 12)
	for x := int32(0); x < spriteSheet.selectionSize; x++ {
		for y := int32(0); y < spriteSheet.selectionSize; y++ {
			_drawRectangle(s.posX+x*spriteSheet.sizePerPixel, s.posY+y*spriteSheet.sizePerPixel, spriteSheet.sizePerPixel, spriteSheet.sizePerPixel, spriteSheet.Data[spriteSheet.spritePosXBasedOnIndex+x][spriteSheet.spritePosYBasedOnIndex+y])
		}
	}
}

// ----------------- Color selector ----------------

type ColorSelector struct {
	posX         int32
	posY         int32
	sizePerColor int32
	Color        int
	Colors       []int
	cols         int
}

func NewColorSelector() *ColorSelector {
	colors := []int{0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15}
	cols := (len(colors) + 3) / 4
	return &ColorSelector{
		posX:         8,
		posY:         8 * 11,
		sizePerColor: 16,
		Color:        0,
		Colors:       colors,
		cols:         cols,
	}
}

func (c *ColorSelector) Update(deltaTime float32) {
	mouseX := _getMouseX()
	mouseY := _getMouseY()

	if _isMouseLeftPressed() {
		for i, color := range c.Colors {
			row := i / c.cols
			col := i % c.cols
			x := c.posX + int32(col)*c.sizePerColor
			y := c.posY + int32(row)*c.sizePerColor
			if mouseX >= x && mouseX < x+c.sizePerColor &&
				mouseY >= y && mouseY < y+c.sizePerColor {
				c.Color = color
				break
			}
		}
	}
}

func (c *ColorSelector) Draw() {
	_drawRectangleLines(c.posX-1, c.posY-1, 64+2, 64+2, 12)
	for i, color := range c.Colors {
		row := i / c.cols
		col := i % c.cols
		x := c.posX + int32(col)*c.sizePerColor
		y := c.posY + int32(row)*c.sizePerColor
		_drawRectangle(x, y, c.sizePerColor, c.sizePerColor, color)
		if color == c.Color {
			_drawRectangleLines(x, y, c.sizePerColor, c.sizePerColor, 7)
		}
	}
}

// ----------------- Timed text ----------------

type TimedText struct {
	text     string
	posX     int32
	posY     int32
	color    int
	visible  bool
	timer    float32
	duration float32
}

func NewTimedText(t float32, x int32, y int32, c int) *TimedText {
	return &TimedText{
		visible:  false,
		timer:    0,
		duration: t,
		posX:     x,
		posY:     y,
		color:    c,
	}
}

func (t *TimedText) Show(text string) {
	t.text = text
	t.visible = true
	t.timer = 0.0
}

func (t *TimedText) Update(deltaTime float32) {
	if t.visible {
		t.timer += deltaTime
		if t.timer >= t.duration {
			t.visible = false
		}
	}
}

func (t *TimedText) Draw() {
	if t.visible {
		_drawText(" "+t.text, t.posX, t.posY, t.color)
	}
}

// ----------------- Main code ----------------

type Object interface {
	Update(deltaTime float32)
	Draw()
}

func _start() {
	objects = []Object{
		NewSpriteAsset(),
		NewSpriteEditor(),
		colorSelector,
		infoText,
	}
	var err error
	spriteSheet.Data, err = _readSprite()
	if err != nil {
		fmt.Println("Error reading file:", err)
		return
	}
}

func _update(deltaTime float32) {
	for _, d := range objects {
		d.Update(deltaTime)
	}

	if _isSaveJustPressed() {
		_saveSprite(spriteSheet.Data)
		infoText.Show("saved")
	}
}

func _draw() {
	for _, d := range objects {
		d.Draw()
	}
}
