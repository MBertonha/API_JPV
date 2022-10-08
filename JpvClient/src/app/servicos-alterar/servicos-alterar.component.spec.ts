import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ServicosAlterarComponent } from './servicos-alterar.component';

describe('ServicosAlterarComponent', () => {
  let component: ServicosAlterarComponent;
  let fixture: ComponentFixture<ServicosAlterarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ServicosAlterarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ServicosAlterarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
