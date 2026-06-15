import { AfterViewInit, OnInit, Component, ElementRef, Renderer2, ViewChild } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit, AfterViewInit {
  @ViewChild("dropdown") dropdownElRef: ElementRef;

  constructor(private renderer: Renderer2){};

  ngOnInit(): void {}
   
  ngAfterViewInit(){
    this.renderer.listen(this.dropdownElRef.nativeElement, 'click', () => {
      this.dropdownElRef.nativeElement.classList.toggle("active");
      var dropdownContent = this.dropdownElRef.nativeElement.nextElementSibling;
      if (dropdownContent.style.display === "block") {
        this.renderer.setStyle(dropdownContent, 'display', 'none');
      } else {
        this.renderer.setStyle(dropdownContent, 'display', 'block');
      }
    });
  }
}
