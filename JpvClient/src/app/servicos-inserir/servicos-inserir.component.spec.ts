import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ServicosInserirComponent } from './servicos-inserir.component';

describe('ServicosInserirComponent', () => {
  let component: ServicosInserirComponent;
  let fixture: ComponentFixture<ServicosInserirComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ServicosInserirComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ServicosInserirComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
