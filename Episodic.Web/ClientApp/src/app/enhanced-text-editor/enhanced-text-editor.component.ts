import { FocusMonitor } from '@angular/cdk/a11y';
import { coerceBooleanProperty } from '@angular/cdk/coercion';
import { AfterViewInit, ElementRef, HostBinding, OnDestroy, Self, ViewChild, ViewEncapsulation } from '@angular/core';
import { Optional } from '@angular/core';
import { ChangeDetectionStrategy, Component, Input } from '@angular/core';
import { ControlValueAccessor, NgControl } from '@angular/forms';
import { MatFormFieldControl } from '@angular/material/form-field';
import { ContentChange, QuillEditorComponent } from 'ngx-quill';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-enhanced-text-editor',
  templateUrl: './enhanced-text-editor.component.html',
  styleUrls: ['./enhanced-text-editor.component.scss'],
  providers: [{provide: MatFormFieldControl, useExisting: EnhancedTextEditorComponent}],
  changeDetection: ChangeDetectionStrategy.OnPush,
  encapsulation: ViewEncapsulation.None
})
export class EnhancedTextEditorComponent implements ControlValueAccessor, AfterViewInit,  OnDestroy {
    static nextId = 0;
    private _value: string;
    get value() {return this._value; }
    set value(v) {
        this._value = v;
        this.stateChanges.next();
        this.updateEditorValue();
    }

    @HostBinding()
    id = `enhanced-text-editor-${EnhancedTextEditorComponent.nextId++}`;
    @HostBinding('class.enhanced-text-editor')
    hostClass = true;
    @HostBinding('class.floating')
    get shouldLabelFloat() {
        return this.focused || !this.empty;
    }
    private _placeholder: string;
    @Input()
    get placeholder() {
        return this._placeholder;
    }
    set placeholder(value) {
        this._placeholder = value;
        this.stateChanges.next();
    }
    stateChanges = new Subject<void>();
    @HostBinding('class.enhanced-text-editor-focused')
    get hasFocusClass() {
        return this.focused;
    }

    @HostBinding('class.enhanced-text-editor-inactive')
    get hasInactiveClass() {
        return !this.focused;
    }

    focused: boolean;
    get empty() {
        return !this.value;
    }



    constructor(@Optional() @Self() public ngControl: NgControl, private fm: FocusMonitor, private elRef: ElementRef<HTMLElement>) {
        this.ngControl.valueAccessor = this;
        fm.monitor(elRef.nativeElement, true).subscribe(origin => {
            this.focused = !!origin;
            this.stateChanges.next();
          });
    }


    private _required = false;
    @Input()
    get required() {
    return this._required;
    }
    set required(req) {
        this._required = coerceBooleanProperty(req);
        this.stateChanges.next();
    }

    private _disabled = false;
    @Input()
    get disabled(): boolean { return this._disabled; }
    set disabled(value: boolean) {
        this._disabled = coerceBooleanProperty(value);
        this.setDisabledState(this._disabled);
        this.stateChanges.next();
    }

    get errorState() {
        if (this.ngControl && this.ngControl.errors) {
            return  true;
        }
        return false;
    }

    controlType = 'enhanced-text-editor';
    // autofilled?: boolean;
    // userAriaDescribedBy?: string;

    editorModules = modules;

    @ViewChild('editor')
    editor: QuillEditorComponent;
    _onTouch: () => void;
    _onChange: (value: string) => void;

    setDescribedByIds(ids: string[]): void {
        if (this.editor) {
            this.editor.editorElem.setAttribute('aria-describedby', ids.join(' '));
        }
    }
    onContainerClick(event: MouseEvent): void {
        // if ((event.target as Element) .tagName.toLowerCase() != 'input') {
        //     this.elRef.nativeElement.querySelector('input').focus();
        //   }
    }
    writeValue(obj: any): void {
        this._value = obj;
        this.updateEditorValue();
    }
    registerOnChange(fn: any): void {
        this._onChange = fn;
    }
    registerOnTouched(fn: any): void {
        this._onTouch = fn;
    }
    setDisabledState?(isDisabled: boolean): void {
        this._disabled = isDisabled;
        this.editor.disabled = isDisabled;
    }

    onTouch() {
        if (this._onTouch) {
            this._onTouch();
        }
    }
    onContentChanged(value: ContentChange) {
        this._value = value.html;
        this.stateChanges.next();
        if (this._onChange) {
            this._onChange(value.html);
        }
    }

    ngAfterViewInit(): void {
        this.updateEditorValue();
    }
    ngOnDestroy() {
        this.stateChanges.complete();
        this.fm.stopMonitoring(this.elRef.nativeElement);
    }

    private updateEditorValue() {
        if (this.editor) {
            this.editor.content = this.value;
        }
    }
}

const modules = {
    toolbar: [
      ['bold', 'italic', 'underline', 'strike'],        // toggled buttons
      ['blockquote'],
      [{ 'header': 1 }, { 'header': 2 }],               // custom button values
      [{ 'list': 'ordered'}, { 'list': 'bullet' }],
      [{ 'script': 'sub'}, { 'script': 'super' }],      // superscript/subscript
      [{ 'indent': '-1'}, { 'indent': '+1' }],          // outdent/indent
      [{ 'direction': 'rtl' }],                         // text direction
      [{ 'size': ['small', false, 'large', 'huge'] }],  // custom dropdown
      [{ 'header': [1, 2, 3, 4, 5, 6, false] }],
      [{ 'color': [] }, { 'background': [] }],          // dropdown with defaults from theme
      [{ 'font': [] }],
      [{ 'align': [] }],
      ['clean'],                                         // remove formatting button
      // ['link', 'image', 'video']                         // link and image, video
    ]
  };
