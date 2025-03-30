import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  constructor(){}
  ngOnInit(): void {


  }
  public isUserAuthenticated: boolean = false;

  public login = () => {

  }
  public logout = () => {

  }
}
