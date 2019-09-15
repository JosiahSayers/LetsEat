import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FamilyRecipeBookComponent } from './family-recipe-book.component';

describe('FamilyRecipeBookComponent', () => {
  let component: FamilyRecipeBookComponent;
  let fixture: ComponentFixture<FamilyRecipeBookComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FamilyRecipeBookComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FamilyRecipeBookComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
