import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ServicosListagemComponent } from './servicos-listagem.component';

describe('ServicosListagemComponent', () => {
  let component: ServicosListagemComponent;
  let fixture: ComponentFixture<ServicosListagemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ServicosListagemComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ServicosListagemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
